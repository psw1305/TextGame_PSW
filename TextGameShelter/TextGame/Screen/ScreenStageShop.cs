namespace Shelter.Screen;

public class ScreenStageShop : IScreen
{
    public static ScreenShopBuy ShopScreen = new();
    public static ScreenShopSell ShopSellScreen = new();

    public static int currentIdx = 0;
    public static string[] selections =
    {
        "구 매",
        "판 매",
        "떠 나 기"
    };

    static void Selection()
    {
        if (currentIdx == 0) 
        {
            ShopScreen.DrawScreen();
        }
        else if (currentIdx == 1)
        {
            ShopSellScreen.DrawScreen();
        }
        else if(currentIdx == 2) 
        {
            Game.NextStage();
        }
    }

    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("상 점 스 테 이 지");
            Console.WriteLine();

            for (int i = 0; i < selections.Length; i++)
            {
                if (i == currentIdx)
                {
                    Console.WriteLine($"▷ {selections[i]}");
                }
                else
                {
                    Console.WriteLine($"   {selections[i]}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("[방향키 ↑ ↓: 위 아래로 이동] [Enter: 선택]");
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
                if (currentIdx > 0)
                    currentIdx--;
                break;
            case Command.MoveBottom:
                if (currentIdx < selections.Length - 1)
                    currentIdx++;
                break;
            case Command.Interact:
                Selection();
                break;
            default:
                break;
        }
    }
}

