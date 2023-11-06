namespace Shelter.Model;

public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int Cap { get; }      // 재화

    public List<Item_Equip> Items = new();

    public Character(string name, string job, int level, int atk, int def, int hp, int cap)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Cap = cap;
    }

    public void DisplayItems()
    {
        Console.WriteLine("[ 아이템 목록 ]");
        Console.WriteLine();

        for (int i = 0; i < Items.Count; i++)
        {
            Items[i].DisplayItemInfo(i + 1);
        }
    }
}