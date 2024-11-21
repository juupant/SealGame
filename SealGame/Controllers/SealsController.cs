using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SealGame.Core.Domain;
using SealGame.Core.Dto;
using SealGame.Core.ServiceInterface;
using SealGame.Data;

namespace SealGame.Controllers
{
    public class SealsController : Controller
    {
        private readonly DatabaseTaskDbContext _context;
        private readonly IFileServices _fileServices;
        private readonly ISealService _sealService;

        public SealsController(IFileServices fileServices, ISealService sealService)
        {
            _fileServices = fileServices;
            _sealService = sealService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SealDto dto)
        {
            var seal = await _sealService.CreateSeal(dto);

            if (seal != null)
            {
                await _fileServices.UploadFilesToDatabase(dto, seal);
                return RedirectToAction("Details", new { id = seal.Id });
            }

            return View(dto);
        }
        public SealsController(DatabaseTaskDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var seals = await _context.Seals
                .Include(s => s.Species) 
                .ToListAsync();
            return View(seals);
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var seal = await _context.Seals
                .Include(s => s.Species) 
                .FirstOrDefaultAsync(m => m.Id == id);

            if (seal == null)
                return NotFound();

            return View(seal);
        }

        
        public IActionResult Create()
        {
            ViewData["SpeciesId"] = new SelectList(_context.SealSpecies, "Id", "Name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Happiness,Hunger,Enrichment,Cleanliness,Species")] Seal seal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SpeciesId"] = new SelectList(_context.SealSpecies, "Id", "Name", seal.Species);
            return View(seal);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var seal = await _context.Seals.FindAsync(id);
            if (seal == null)
                return NotFound();

            ViewData["SpeciesId"] = new SelectList(_context.SealSpecies, "Id", "Name", seal.Species);
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
                    _context.Update(seal);
                    await _context.SaveChangesAsync();
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

            ViewData["SpeciesId"] = new SelectList(_context.SealSpecies, "Id", "Name", seal.Species);
            return View(seal);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var seal = await _context.Seals
                .Include(s => s.Species)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (seal == null)
                return NotFound();

            return View(seal);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seal = await _context.Seals.FindAsync(id);
            _context.Seals.Remove(seal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SealExists(int id)
        {
            return _context.Seals.Any(e => e.Id == id);
        }
    }
}
