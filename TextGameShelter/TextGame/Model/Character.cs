using Shelter.Model.Item;

namespace Shelter.Model;

public class Character
{
    public string Name { get; }
    public string Job { get; }

    public int Atk { get; set; }
    public int Def { get; set; }
    public int Hp { get; set; }
    public int Cash { get; set; }

    public List<IItem> Inventory;
    public Equipment Equipment;

    public Character(string name, string job, int atk, int def, int hp, int cash, List<IItem> inventory, Equipment equipment)
    {
        Name = name;
        Job = job;
        Atk = atk;
        Def = def;
        Hp = hp;
        Cash = cash;
        Inventory = inventory;
        Equipment = equipment;
    }

    public bool IsTrade(int price)
    {
        if (Cash >= price)
        {
            Cash -= price;
            return true;
        }
        else
        { 
            return false; 
        }
    }
}