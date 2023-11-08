using Shelter.Core;
using Shelter.Model;

namespace Shelter.Screen;

public class ScreenEquipment
{
    public static int currentItemIdx = 0;
    public static int currentItemsLength = GameManager.player.Inventory.Count - 1;

    public static void DisplayEquipment()
    {
        do
        {
            Console.Clear();

            Console.Write("[인벤토리] - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("장착 관리");
            Console.WriteLine();
            Console.ResetColor();

            // 아이템 목록 표시
            GameManager.player.DisplayEquipmentList(currentItemIdx);

            Console.WriteLine();
            Console.WriteLine("[방향키 ↑ ↓: 위 아래로 이동, Enter: 아이템 장착, Exit: 인벤토리로 돌아가기]");
        }
        while (ManageInput());
    }

    /// <summary>
    /// 인벤토리에서 아이템 장착
    /// </summary>
    static void EquipFromInventory()
    {
        var item = GameManager.player.Inventory.ElementAtOrDefault(currentItemIdx);
        if (item == null || item.IsEmptyItem()) return;

        var equipItem = (ItemEquip)item;
        if (equipItem != null)
        {
            switch (equipItem.Type) 
            {
                case EquipType.Weapon:
                    GameManager.player.Equipment.Equip(EquipSlot.Weapon, equipItem);
                    break;
                case EquipType.Armor:
                    GameManager.player.Equipment.Equip(EquipSlot.Armor, equipItem);
                    break;
            }
        }
    }

    static bool ManageInput()
    {
        var key = Console.ReadKey();

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
                ScreenInventory.DisplayInventory();
                break;

            default:
                break;
        }
    }
}