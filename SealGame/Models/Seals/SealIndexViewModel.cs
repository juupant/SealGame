using Microsoft.AspNetCore.Mvc;

namespace SealGame.Models.Seals
{
    public class SealIndexViewModel : Controller
    {
        public string? Name { get; set; }
        public int SpeciesId { get; set; }

        public int Happiness { get; set; }
        public int Hunger { get; set; }
        public int Enrichment { get; set; }
        public int Cleanliness { get; set; }

        //db
        public DateTime? SealCreated { get; set; }

    }
}
