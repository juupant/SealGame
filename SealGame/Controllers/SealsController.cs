using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SealGame.Core.Domain;
using SealGame.Core.ServiceInterface;
using SealGame.Data;
using SealGame.ApplicationServices.Services;
using SealGame.Models.Seals;
namespace SealGame.Controllers
{
    public class SealsController : Controller
    {
        private readonly DatabaseTaskDbContext _context;
        private readonly ISealService _sealService;

        public SealsController(DatabaseTaskDbContext context, ISealService sealService)
        {
            _context = context;
            _sealService = sealService;
        }


        public async Task<IActionResult> Index()
        {
            var seals = await _sealService.GetAllSealsAsync();
            return View(seals);
        }


        public async Task<IActionResult> Details(int id)
        {
            var seal = await _context.Seals
                .Include(s => s.Species)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (seal == null)
                return NotFound();

            var viewModel = new SealImageViewModel
            {
                ImageName = seal.Name,
                SpeciesId = seal.SpeciesId,
                
            };

            return View(viewModel);
        }



        public IActionResult Create()
        {
            ViewData["SpeciesId"] = new SelectList(_context.SealSpecies, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SealImageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;

                if (viewModel.ImageFile != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await viewModel.ImageFile.CopyToAsync(ms);
                        imageData = ms.ToArray();
                    }
                }

                var seal = new Seal
                {
                    Name = viewModel.ImageName,
                    SpeciesId = viewModel.SpeciesId,
                    ImageData = imageData
                };

                _context.Seals.Add(seal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SpeciesId"] = new SelectList(_context.SealSpecies, "Id", "Name", viewModel.SpeciesId);
            return View(viewModel);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var seal = await _sealService.GetSealByIdAsync(id.Value);
            if (seal == null)
                return NotFound();

            ViewData["SpeciesId"] = new SelectList(_context.SealSpecies, "Id", "Name", seal.SpeciesId);
            return View(seal);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Happiness,Hunger,Enrichment,Cleanliness,SpeciesId")] Seal seal)
        {
            if (id != seal.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _sealService.UpdateSealStatsAsync(id, seal.Happiness, seal.Hunger, seal.Enrichment, seal.Cleanliness);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SealExists(seal.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["SpeciesId"] = new SelectList(_context.SealSpecies, "Id", "Name", seal.SpeciesId);
            return View(seal);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var seal = await _sealService.GetSealByIdAsync(id.Value);

            if (seal == null)
                return NotFound();

            return View(seal);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sealService.DeleteSealAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Feed(int id)
        {
            var seal = await _sealService.FeedSealAsync(id);
            if (seal == null)
                return NotFound();

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Play(int id)
        {
            var seal = await _sealService.PlayWithSealAsync(id);
            if (seal == null)
                return NotFound();

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Clean(int id)
        {
            var seal = await _sealService.CleanSealAsync(id);
            if (seal == null)
                return NotFound();

            return RedirectToAction(nameof(Details), new { id });
        }

        private bool SealExists(int id)
        {
            return _context.Seals.Any(e => e.Id == id);
        }
    }
}
