using ConsoleTables;
using Shelter.Core;
using Shelter.Model.Item;
using static System.Console;

namespace Shelter.Screen;

public class ScreenShopSell : IScreen
{
    public static int currentItemIdx = 0;
    public static List<IItem> Inventory = Game.player.Inventory;

    static void Sell()
    {
        var item = Game.player.Inventory[currentItemIdx];
        if (item == null || item.IsEmptyItem()) return;

        Game.player.Cash += item.ToPrice();
        Game.player.Inventory.Remove(item);
    }

    /// <summary>
    /// 상품 리스트 전시
    /// </summary>
    public void DrawInvenList()
    {
        var inventory = Game.player.Inventory;
        var table = new ConsoleTable("선택", "이름", "타입", "설명", "판매가");

        for (int i = 0; i < inventory.Count; i++)
        {
            var selectArrow = string.Empty;

            if (i == currentItemIdx) selectArrow = "▷";

            table.AddRow(selectArrow, inventory[i].Name, inventory[i].ItemType.TypeToString(), inventory[i].Desc, inventory[i].ToPrice());
        }

        table.Write();
        WriteLine();
    }

    public void DrawScreen()
    {
        do
        {
            Clear();
            Write("[ 상 점 ] - ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("판 매");
            WriteLine();
            ResetColor();

            WriteLine();
            Write($"[ 보 유 현 금 : {Game.player.Cash}]");
            WriteLine();

            DrawInvenList();

            WriteLine();
            WriteLine("[방향키 ↑ ↓: 위 아래로 이동] [Enter: 아이템 판매] [Esc: 상점]");
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
                if (currentItemIdx < Game.player.Inventory.Count - 1)
                    currentItemIdx++;
                break;
            case Command.Interact:
                Sell();
                break;
            case Command.Exit:
                Game.CurrentStage();
                break;
            default:
                break;
        }
    }
}
