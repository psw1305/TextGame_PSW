namespace Shelter.Model;

public interface IItem
{
    public string Name { get; }
    public string Desc { get; }
    public int Price { get; }
}
