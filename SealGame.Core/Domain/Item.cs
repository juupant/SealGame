using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SealGame.Core.Domain;

namespace SealGame.Core.Domain { }
    public class Item
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public ItemType Type { get; set; }
    public int EffectAmount { get; set; }

    public Item(string name, int cost, ItemType type, int effectAmount)
    {
        Name = name;
        Cost = cost;
        Type = type;
        EffectAmount = effectAmount;
    }

    public void ApplyEffect(Seal seal)
    {
        switch (Type)
        {
            case ItemType.Food:
                seal.Hunger = Math.Max(seal.Hunger - EffectAmount, 0);
                break;
            case ItemType.Toy:
                seal.Enrichment = Math.Min(seal.Enrichment + EffectAmount, 100);
                break;
            case ItemType.CleaningTool:
                seal.Cleanliness = Math.Min(seal.Cleanliness + EffectAmount, 100);
                break;
        }
    }
}

public enum ItemType
{
    Food,
    Toy,
    CleaningTool
}