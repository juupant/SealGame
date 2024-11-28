using Microsoft.AspNetCore.Mvc;

namespace SealGame.Models.Seals
{
    public class SealDeleteViewModel : Controller
    {
        public string? Name { get; set; }
        public int SpeciesId { get; set; }

        public int Happiness { get; set; }
        public int Hunger { get; set; }
        public int Enrichment { get; set; }
        public int Cleanliness { get; set; }
        //db
        public DateTime? SealCreated { get; set; }

        public List<IFormFile>? Files { get; set; }
        public List<SealImageViewModel> Image { get; set; } = new List<SealImageViewModel>();
    }
}