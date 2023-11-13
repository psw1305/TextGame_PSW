using ConsoleTables;
using Shelter.Core;
using Shelter.Model.Item;

namespace Shelter.Screen;

public class ScreenShopBuy : IScreen
{
    public static int selectionIdx = 0;
    public static List<IItem> productLists = Game.ShopProducts.ToList();

    static void Buy()
    {
        var item = productLists[selectionIdx];
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

            if (i == selectionIdx) selectArrow = "▷";

            table.AddRow(selectArrow, productLists[i].Name, productLists[i].ItemType.TypeToString(), productLists[i].Desc, productLists[i].Price);
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
            Console.Write($"[ 보 유 현 금 : {Game.Player.Cash}]");
            Console.WriteLine();

            DrawProductList();
            //Renderer.DrawBorder();
            //Renderer.DrawSideBorder();
            //Renderer.Print(4, "[ 상 점 ] - 구 매");
            //Renderer.PrintSideAll();
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
                if (selectionIdx > 0)
                    selectionIdx--;
                break;
            case Command.MoveBottom:
                if (selectionIdx < productLists.Count - 1)
                    selectionIdx++;
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
