namespace Shelter.Model.Item;

public enum ItemType
{
    Equipment,
    Useable,
    Material
}

public interface IItem
{
    public ItemType ItemType { get; }
    public string Name { get; }
    public string Desc { get; }
    public int Price { get; }
}
