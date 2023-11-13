using Shelter.Model.Item;

namespace Shelter.Model;

public class Character
{
    public string Name { get; }
    public string Job { get; }

    public int Hp { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Acc { get; set; }
    public int Eva { get; set; }
    public int Cash { get; set; }

    public List<IItem> Inventory;
    public Equipment Equipment;

    public Character(string name, string job, int hp, int atk, int def, int acc, int eva, Equipment equipment)
    {
        Name = name;
        Job = job;
        Atk = atk;
        Def = def;
        Acc = acc;
        Eva = eva;
        Hp = hp;
        Equipment = equipment;
    }

    public void Damaged(int damage)
    {
        if (damage <= Def) return; 

        Hp -= (damage - Def);

        if (Hp <= 0)
        {
            Hp = 0;
        }
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