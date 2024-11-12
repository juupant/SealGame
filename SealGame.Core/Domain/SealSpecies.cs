using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealGame.Core.Domain
{
    public class SealSpecies
    {
        public string Name { get; set; }
        public int MaxHappiness { get; set; }
        public int HungerTolerance { get; set; }
        public int EnrichmentThreshold { get; set; }
        public string Description { get; set; }

        public SealSpecies(string name, int maxHappiness, int hungerTolerance, int enrichmentThreshold, string description)
        {
            Name = name;
            MaxHappiness = maxHappiness;
            HungerTolerance = hungerTolerance;
            EnrichmentThreshold = enrichmentThreshold;
            Description = description;
        }
    }
    public class SealSpeciesRepository
    {
        public static SealSpecies WeddellSeal = new SealSpecies(
            "Weddell Seal",
            maxHappiness: 100,
            hungerTolerance: 100,
            enrichmentThreshold: 100,
            description: "paks poiss"
        );

        public static SealSpecies RingedSeal = new SealSpecies(
            "Ringed Seal",
            maxHappiness: 100,
            hungerTolerance: 90,
            enrichmentThreshold: 90,
            description: "yo-chan"
        );
                public static SealSpecies CrabeaterSeal = new SealSpecies(
            "Crabeater Seal",
            maxHappiness: 100,
            hungerTolerance: 80,
            enrichmentThreshold: 80,
            description: "imelik kutt"
        );
                public static SealSpecies BaikalSeal = new SealSpecies(
            "Baikal Seal",
            maxHappiness: 100,
            hungerTolerance: 70,
            enrichmentThreshold: 70,
            description: "nerpa"
        );
                public static SealSpecies RibbonSeal = new SealSpecies(
            "Ribbon Seal",
            maxHappiness: 100,
            hungerTolerance: 60,
            enrichmentThreshold: 60,
            description: "vöödiline"
        );
                public static SealSpecies LeopardSeal = new SealSpecies(
            "Leopard Seal",
            maxHappiness: 100,
            hungerTolerance: 50,
            enrichmentThreshold: 50,
            description: "hirmus koll"
        );
    }
}
