using ConsoleTables;
using Shelter.Core;
using Shelter.Model.Item;
using static System.Console;

namespace Shelter.Screen;

public class ScreenShopBuy : IScreen
{
    public static int currentItemIdx = 0;
    public static List<IItem> productLists = Game.ShopProducts.ToList();

    static void Buy()
    {
        var item = productLists[currentItemIdx];
        if (item == null || item.IsEmptyItem()) return;

        if (Game.Player.IsTrade(item.Price))
        {
            Game.Player.Inventory.Add(item);
            productLists.Remove(item);
        }
    }

    /// <summary>
    /// 상품 리스트 전시
    /// </summary>
    public void DrawProductList()
    {
        var table = new ConsoleTable("선택", "이름", "타입", "설명", "가격");

        for (int i = 0; i < productLists.Count; i++)
        {
            var selectArrow = string.Empty;

            if (i == currentItemIdx) selectArrow = "▷";

            table.AddRow(selectArrow, productLists[i].Name, productLists[i].ItemType.TypeToString(), productLists[i].Desc, productLists[i].Price);
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
            WriteLine("구 매");
            WriteLine();
            ResetColor();

            WriteLine();
            Write($"[ 보 유 현 금 : {Game.Player.Cash}]");
            WriteLine();

            DrawProductList();

            WriteLine();
            WriteLine("[방향키 ↑ ↓: 위 아래로 이동] [Enter: 상품 구매] [Esc: 상점]");
            WriteLine($"{Game.Player.Inventory.Count}");
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
                if (currentItemIdx < productLists.Count - 1)
                    currentItemIdx++;
                break;
            case Command.Interact:
                Buy();
                break;
            case Command.Exit:
                Game.CurrentStage();
                break;
            default:
                break;
        }
    }
}
