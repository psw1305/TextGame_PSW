namespace Shelter.Model.Item;

public class ItemUseable : IItem
{
    public ItemType ItemType { get; }
    public string Name { get; }
    public string Desc { get; }
    public int Price { get; }

    public ItemUseable(string name, string desc, int price, ItemType itemType = ItemType.Useable)
    {
        ItemType = itemType;
        Name = name;
        Desc = desc;
        Price = price;
    }
}
