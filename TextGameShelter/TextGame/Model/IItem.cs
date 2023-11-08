namespace Shelter.Model;

public interface IItem
{
    public string Name { get; }     // 아이템 이름
    public string Desc { get; }     // 아이템 설명
    public int Price { get; }       // 아이템 가격
}
