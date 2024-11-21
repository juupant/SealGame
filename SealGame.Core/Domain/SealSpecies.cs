using System.Collections.Generic;

namespace SealGame.Core.Domain
{
    public class SealSpecies
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxHappiness { get; set; }
        public int MaxHunger { get; set; }
        public int MaxEnrichment { get; set; }
        public int MaxCleanliness { get; set; }

        public List<Seal> Seals { get; set; } = new List<Seal>(); 

        
        public SealSpecies() { }

        
        public SealSpecies(string name, string description, int maxHappiness, int maxHunger, int maxEnrichment, int maxCleanliness)
        {
            Name = name;
            Description = description;
            MaxHappiness = maxHappiness;
            MaxHunger = maxHunger;
            MaxEnrichment = maxEnrichment;
            MaxCleanliness = maxCleanliness;
        }
    }
}
