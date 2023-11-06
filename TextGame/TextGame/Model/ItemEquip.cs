namespace Shelter.Model;

public class ItemEquip : IItem
{
    public EquipType Type;
    public int Stat;

    public ItemEquip(string name, string desc, EquipType type, int stat)
    {
        Name = name;
        Desc = desc;
        Type = type;
        Stat = stat;
    }

    public string Name { get; }
    public string Desc { get; }
    public int Price { get; }

    public void DisplayItemInfo(int num)
    {
        Console.WriteLine($"- {num} | {DisplayStat()} | {Desc}");
    }

    private string DisplayStat()
    {
        if (Type == EquipType.Weapon)
        {
            return "공격력 +" + Stat;
        }
        else
        {
            return "방어력 +" + Stat;
        }
    }
}

public enum EquipType
{
    Weapon = 1,
    Armor = 2,
}
