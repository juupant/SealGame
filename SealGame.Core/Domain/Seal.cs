using System.ComponentModel.DataAnnotations;

namespace SealGame.Core.Domain
{
    public class Seal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Happiness { get; set; }
        public int Hunger { get; set; }
        public int Enrichment { get; set; }
        public int Cleanliness { get; set; }

        
        public int SpeciesId { get; set; }

        public SealSpecies Species { get; set; }
        public byte[] ImageData { get; set; }



        public Seal() { }

        
        public Seal(string name, SealSpecies species)
        {
            Name = name;
            Species = species;
            Happiness = species.MaxHappiness / 2;
            Hunger = 0;
            Enrichment = 0;
            Cleanliness = 100;
        }
    }
}
