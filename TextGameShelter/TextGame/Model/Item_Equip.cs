namespace Shelter.Model;

public enum EquipType
{
    Weapon,
    Armor,
    None
}

public class Item_Equip : IItem
{
    public EquipType Type;
    public int Stat;

    public Item_Equip(string name, string desc, EquipType type, int stat)
    {
        Name = name;
        Desc = desc;
        Type = type;
        Stat = stat;
    }

    // 빈 아이템
    public static Item_Equip Empty = new("", "", EquipType.None, 0);

    public string Name { get; }
    public string Desc { get; }
    public int Price { get; }

    public void DisplayItemInfo(int num)
    {
        Console.WriteLine($"| [{num}] | {Name} | {Type}  | {DisplayStat()} | {Desc} |");
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
