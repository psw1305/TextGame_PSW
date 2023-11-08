namespace Shelter.Model;

public enum EquipType
{
    Weapon,
    Armor,
    None
}

public class ItemEquip : IItem
{
    public bool IsEquipped = false;
    public EquipType Type;
    public int Stat;

    public ItemEquip(string name, string desc, EquipType type, int stat)
    {
        Name = name;
        Desc = desc;
        Type = type;
        Stat = stat;
    }

    public static ItemEquip Empty = new(string.Empty, string.Empty, EquipType.None, 0);

    public string Name { get; }
    public string Desc { get; }
    public int Price { get; }
}
