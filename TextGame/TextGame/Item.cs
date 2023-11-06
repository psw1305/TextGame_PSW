public enum ItemType
{
    Weapon = 1,
    Armor = 2,
}

public class Item
{
    public string Name { get; }
    public ItemType Type { get; }
    public int Stat { get; }
    public string Info { get; }
    public bool IsEquip { get; }

    public Item(string name, ItemType type, int stat, string info, bool isEquip)
    {
        Name = name;
        Type = type;
        Stat = stat;
        Info = info;
        IsEquip = isEquip;
    }

    public void DisplayItemInfo(int num)
    {
        Console.WriteLine($"- {num} {DisplayEquipCheck()} | {DisplayStat()} | {Info}");
    }

    private string DisplayEquipCheck()
    {
        if (IsEquip)
        {
            return "[E]" + Name;
        }
        else
        {
            return Name;
        }
    }

    private string DisplayStat()
    {
        if (Type == ItemType.Weapon)
        {
            return "공격력 +" + Stat;
        }
        else 
        {
            return "방어력 +" + Stat;
        }
    }
}
