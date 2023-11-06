namespace Shelter.Model;

public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int Gold { get; }

    private ItemEquip[] Items;

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

        Items = new ItemEquip[2];
        Items[0] = new ItemEquip("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", EquipType.Armor, 5);
        Items[1] = new ItemEquip("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", EquipType.Weapon, 2);

        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].DisplayItemInfo(i + 1);
        }
    }
}