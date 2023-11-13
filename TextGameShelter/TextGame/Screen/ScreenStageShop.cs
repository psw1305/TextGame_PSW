using Shelter.Core;

namespace Shelter.Screen;

public class ScreenStageShop : IScreen
{
    public static ScreenShopBuy ShopBuyScreen = new();
    public static ScreenShopSell ShopSellScreen = new();

    private static int selectionIdx = 0;
    private static string[] selections =
    {
        "구 매",
        "판 매",
        "떠 나 기"
    };

    static void Selection()
    {
        if (selectionIdx == 0) 
        {
            ShopBuyScreen.DrawScreen();
        }
        else if (selectionIdx == 1)
        {
            ShopSellScreen.DrawScreen();
        }
        else if(selectionIdx == 2) 
        {
            Game.NextStage();
        }
    }

    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Renderer.DrawBorder();
            Renderer.DrawSideBorder();
            Renderer.Print(4, "[ 상 점 ]");
            Renderer.PrintKeyGuide("[Enter] 선택");
            Renderer.PrintSelections(8, selectionIdx, selections);
            Renderer.PrintSideAll();
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
            ConsoleKey.I => Command.Inventory,
            ConsoleKey.Enter => Command.Interact,
            _ => Command.Nothing
        };

        OnCommand(commands);
        return commands != Command.Interact;
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
                if (selectionIdx < selections.Length - 1)
                    selectionIdx++;
                break;
            case Command.Inventory:
                Game.screen.DisplayScreen(ScreenType.Inventory);
                break;
            case Command.Interact:
                Selection();
                selectionIdx = 0;
                break;
            default:
                break;
        }
    }
}

