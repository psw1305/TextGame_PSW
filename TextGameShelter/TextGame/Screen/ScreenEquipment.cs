using ConsoleTables;
using Shelter.Core;
using Shelter.Model;
using Shelter.Model.Item;

namespace Shelter.Screen;

public class ScreenEquipment : IScreen
{
    public static int currentItemIdx = 0;
    public static int currentItemsLength = Game.player.Inventory.Count - 1;

    /// <summary>
    /// 인벤토리에서 아이템 장착
    /// </summary>
    static void EquipFromInventory()
    {
        var item = Game.player.Inventory.ElementAtOrDefault(currentItemIdx);
        if (item == null || item.IsEmptyItem()) return;

        var equipItem = (ItemEquip)item;
        if (equipItem != null)
        {
            switch (equipItem.EquipType) 
            {
                case EquipType.Weapon:
                    Game.player.Equipment.Equip(EquipSlot.Weapon, equipItem);
                    break;
                case EquipType.Armor:
                    Game.player.Equipment.Equip(EquipSlot.Armor, equipItem);
                    break;
            }
        }
    }

    /// <summary>
    /// 장비 아이템 리스트 전시
    /// </summary>
    public void DrawEquipmentList()
    {
        var player = Game.player;
        var table = new ConsoleTable("선택", "착용 상태", "이름", "타입", "능력치", "설명");
        List<IItem> equipItemList = player.Inventory.Where(item => item.ItemType.TypeToString() == "장비").ToList();

        for (int i = 0; i < equipItemList.Count; i++)
        {
            var equipItem = (ItemEquip)equipItemList[i];
            var selectArrow = string.Empty;

            if (i == currentItemIdx) selectArrow = "▷";

            table.AddRow(selectArrow, equipItem.EquippedToString(), equipItem.Name, equipItem.EquipType.TypeToString(), equipItem.StatToString(), equipItem.Desc);
        }

        table.Write();
        Console.WriteLine();
    }

    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("[ 인 벤 토 리 ] - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("장 착 관 리");
            Console.WriteLine();
            Console.ResetColor();

            // 장비 아이템 목록 전시
            DrawEquipmentList();

            Console.WriteLine();
            Console.WriteLine("[방향키 ↑ ↓: 위 아래로 이동] [Enter: 아이템 장착] [Esc: 인벤토리로 돌아가기]");
        }
        while (ManageInput());
    }

    public bool ManageInput()
    {
        var key = Console.ReadKey(true);

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
                if (currentItemIdx < currentItemsLength)
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