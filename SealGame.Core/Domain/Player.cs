using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SealGame.Core.Domain;

namespace SealGame.Core.Domain { }
public class Player
{
    public string Name { get; set; }
    public int Currency { get; set; }
    public int Level { get; set; }
    public List<Item> Inventory { get; set; }
    public List<Seal> SealsOwned { get; set; }
    public int DailyTasksCompleted { get; set; }

    public Player(string name, int startingCurrency)
    {
        Name = name;
        Currency = startingCurrency;
        Level = 1;
        Inventory = new List<Item>();
        SealsOwned = new List<Seal>();
        DailyTasksCompleted = 0;
    }

    public bool BuyItem(Item item)
    {
        if (Currency >= item.Cost)
        {
            Currency -= item.Cost;
            Inventory.Add(item);
            return true; 
        }
        return false; 
    }

    public bool UseItem(Seal seal, Item item)
    {
        if (Inventory.Contains(item))
        {
            item.ApplyEffect(seal);
            Inventory.Remove(item);
            return true; 
        }
        return false;
    }

    public void LevelUp()
    {
        Level++;
    }

    public void CompleteTask(int reward)
    {
        DailyTasksCompleted++;
        Currency += reward;
    }

    public List<Item> GetInventory()
    {
        return Inventory;
    }

    public List<Seal> GetSeals()
    {
        return SealsOwned;
    }
}
