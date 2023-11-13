using ConsoleTables;
using Shelter.Core;
using Shelter.Model;
using Shelter.Model.Item;
using static System.Console;

namespace Shelter.Screen;

public class ScreenEquipment : IScreen
{
    static int currentItemIdx;
    static List<IItem> equipItemList;

    public ScreenEquipment()
    {
        currentItemIdx = 0;
        equipItemList = Game.Player.Inventory.Where(item => item.ItemType.TypeToString() == "장비").ToList();
    }

    /// <summary>
    /// 인벤토리에서 아이템 장착
    /// </summary>
    static void EquipFromInventory()
    {
        var item = equipItemList.ElementAtOrDefault(currentItemIdx);
        if (item == null || item.IsEmptyItem()) return;

        if (item is ItemEquip equipItem)
        {
            switch (equipItem.EquipType)
            {
                case EquipType.Weapon:
                    Game.Player.Equipment.Equip(EquipSlot.Weapon, equipItem);
                    break;
                case EquipType.Armor:
                    Game.Player.Equipment.Equip(EquipSlot.Armor, equipItem);
                    break;
            }
        }
    }

    /// <summary>
    /// 장비 아이템 리스트 전시
    /// </summary>
    public void DrawEquipmentList()
    {
        var table = new ConsoleTable("선택", "착용 상태", "이름", "타입", "능력치", "설명");

        for (int i = 0; i < equipItemList.Count; i++)
        {
            var equipItem = (ItemEquip)equipItemList[i];
            var selectArrow = string.Empty;

            if (i == currentItemIdx) selectArrow = "▷";

            table.AddRow(selectArrow, equipItem.EquippedToString(), equipItem.Name, equipItem.EquipType.TypeToString(), equipItem.StatToString(), equipItem.Desc);
        }

        table.Write();
        WriteLine();
    }

    public void DrawScreen()
    {
        do
        {
            Clear();
            WriteLine();
            Write("[ 인 벤 토 리 ] - ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("장 착 관 리");
            WriteLine();
            ResetColor();

            // 장비 아이템 목록 전시
            DrawEquipmentList();

            WriteLine();
            WriteLine("[방향키 ↑ ↓: 위 아래로 이동] [Enter: 아이템 장착] [Esc: 인벤토리]");
        }
        while (ManageInput());
    }

    public bool ManageInput()
    {
        var key = ReadKey(true);

        var commands = key.Key switch
        {
            ConsoleKey.UpArrow => Command.MoveTop,
            ConsoleKey.DownArrow => Command.MoveBottom,
            ConsoleKey.Enter => Command.Interact,
            ConsoleKey.Escape => Command.Exit,
            _ => Command.Nothing
        };

        OnCommand(commands);
        return commands != Command.Exit;
    }

    static void OnCommand(Command cmd)
    {
        switch (cmd)
        {
            case Command.MoveTop:
                if (currentItemIdx > 0)
                    currentItemIdx--;
                break;
            case Command.MoveBottom:
                if (currentItemIdx < equipItemList.Count - 1)
                    currentItemIdx++;
                break;
            case Command.Interact:
                EquipFromInventory();
                break;
            case Command.Exit:
                Game.screen.DisplayScreen(ScreenType.Inventory);
                break;
            default:
                break;
        }
    }
}