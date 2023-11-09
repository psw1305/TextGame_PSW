using Shelter.Model.Item;

namespace Shelter.Model;

public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int Cash { get; }

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
}