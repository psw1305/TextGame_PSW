using ConsoleTables;
using Shelter.Core;

namespace Shelter.Model;

public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int Cash { get; }

    public List<IItem> Inventory;
    public Equipment Equipment;

    public Character(string name, string job, int level, int atk, int def, int hp, int cash, List<IItem> inventory, Equipment equipment)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Cash = cash;
        Inventory = inventory;
        Equipment = equipment;
    }

    /// <summary>
    /// 인벤토리 아이템 리스트 전시
    /// </summary>
    public void DisplayInventoryList()
    {
        var table = new ConsoleTable("번호", "이름", "타입", "능력치", "설명");

        for (int i = 0; i < Inventory.Count; i++)
        {
            var equipItem = (ItemEquip)Inventory[i];
            table.AddRow(i + 1, equipItem.Name, equipItem.Type.TypeToString(), equipItem.StatToString(), equipItem.Desc);
        }

        table.Write();
        Console.WriteLine();
    }

    /// <summary>
    /// 장비 아이템 리스트 전시
    /// </summary>
    public void DisplayEquipmentList(int selectNum)
    {
        var table = new ConsoleTable("선택", "착용 상태","이름", "타입", "능력치", "설명");

        for (int i = 0; i < Inventory.Count; i++)
        {
            var equipItem = (ItemEquip)Inventory[i];
            var selectArrow = string.Empty;

            if (i == selectNum) selectArrow = "▷";

            table.AddRow(selectArrow, equipItem.EquippedToString(), equipItem.Name, equipItem.Type.TypeToString(), equipItem.StatToString(), equipItem.Desc);
        }

        table.Write();
        Console.WriteLine();
    }
}