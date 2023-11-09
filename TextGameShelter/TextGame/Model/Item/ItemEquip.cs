namespace Shelter.Model.Item;

public enum EquipType
{
    Weapon,
    Armor,
    None
}

public class ItemEquip : IItem
{
    public ItemType ItemType { get; }
    public string Name { get; }
    public string Desc { get; }
    public int Price { get; }

    public EquipType EquipType { get; }
    public int Stat { get; }
    public bool IsEquipped { get; set; }

    public ItemEquip(EquipType equipType, string name, string desc, int price, int stat, ItemType itemType = ItemType.Equipment)
    {
        ItemType = itemType;
        EquipType = equipType;
        Name = name;
        Desc = desc;
        Price = price;
        Stat = stat;
    }

    public static ItemEquip Empty = new(EquipType.None, string.Empty, string.Empty, 0, 0);
}
