using ConsoleTables;
using Shelter.Core;
using Shelter.Model.Item;
using static System.Console;

namespace Shelter.Screen;

public class ScreenInventory : IScreen
{
    private static List<IItem> screenInventory;

    public ScreenInventory()
    {
        screenInventory = Game.player.Inventory.ToList();
    }

    /// <summary>
    /// 인벤토리 아이템 리스트 전시
    /// </summary>
    private void DrawInventoryList()
    {
        var table = new ConsoleTable("번 호", "이 름", "타 입", "설 명", "가 격");

        for (int i = 0; i < screenInventory.Count; i++)
        {
            table.AddRow(i + 1, screenInventory[i].Name, screenInventory[i].ItemType.TypeToString(), screenInventory[i].Desc, screenInventory[i].Price);
        }

        table.Write();
        WriteLine();
    }

    // 인벤토리 정보 표시
    public void DrawScreen()
    {
        do
        {
            Clear();
            WriteLine();
            WriteLine("[ 인 벤 토 리 ]");
            WriteLine();

            // 모든 아이템 목록 전시
            DrawInventoryList();

            WriteLine($"▷ 장 비 관 리");
            WriteLine();
            WriteLine("[Enter: 장비관리] [Esc: 메인화면]");
            WriteLine("[정렬 : 1. 이름  2. 가격  3. 타입]");
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
            ConsoleKey.D1 => Command.Num1,
            ConsoleKey.D2 => Command.Num2,
            ConsoleKey.D3 => Command.Num3,
            _ => Command.Nothing
        };

        OnCommand(commands);
        return commands != Command.Exit;
    }

    static void OnCommand(Command cmd)
    {
        switch (cmd)
        {
            case Command.Interact:
                Game.screen.DisplayScreen(ScreenType.Equipment);
                break;
            case Command.Exit:
                Game.screen.DisplayScreen(ScreenType.Main);
                break;
            case Command.Num1:
                screenInventory = Game.player.Inventory.OrderBy(item => item.Name).ToList();
                break;
            case Command.Num2:
                screenInventory = Game.player.Inventory.OrderByDescending(item => item.Price).ToList();
                break;
            case Command.Num3:
                screenInventory = Game.player.Inventory.OrderBy(item => item.ItemType).ToList();
                break;
            default:
                break;
        }
    }
}
