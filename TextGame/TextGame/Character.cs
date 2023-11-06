public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int Gold { get; }

    private Item[] Items;

    public Character(string name, string job, int level, int atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
    }

    public void DisplayItems()
    {
        Console.WriteLine("[ 아이템 목록 ]");

        Items = new Item[2];
        Items[0] = new Item("무쇠갑옷", ItemType.Armor, 5, "무쇠로 만들어져 튼튼한 갑옷입니다.", true);
        Items[1] = new Item("낡은 검", ItemType.Weapon, 2, "쉽게 볼 수 있는 낡은 검입니다.", false);

        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].DisplayItemInfo(i + 1);
        }
    }
}