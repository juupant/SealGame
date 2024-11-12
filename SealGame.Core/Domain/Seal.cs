using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealGame.Core.Domain
{
    public class Seal
    {
        [Key]
        public string Name { get; set; }
        public SealSpecies Species { get; set; }
        public int Happiness { get; set; }
        public int Hunger { get; set; }
        public int Enrichment { get; set; }
        public int Cleanliness { get; set; }
        public Seal(string name, SealSpecies species)
        {
            Name = name;
            Species = species;
            Happiness = species.MaxHappiness / 2; // Start at half of max
            Hunger = species.HungerTolerance / 2;
            Enrichment = species.EnrichmentThreshold / 2;
            Cleanliness = 100; // Clean by default
        }
    }
}
