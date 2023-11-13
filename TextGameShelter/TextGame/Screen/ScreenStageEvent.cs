using Shelter.Core;

namespace Shelter.Screen;

public class ScreenStageEvent : IScreen
{
    public static int currentIdx = 0;
    public static string[] selectNames =
    {
        "계 속 하 기",
    };

    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Renderer.DrawBorder();
            Renderer.DrawSideBorder();
            Renderer.Print(4, "[ 이 벤 트 ]");
            Renderer.PrintKeyGuide("[Enter] 스테이지 넘기기");
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
                if (currentIdx > 0)
                    currentIdx--;
                break;
            case Command.MoveBottom:
                if (currentIdx < selectNames.Length - 1)
                    currentIdx++;
                break;
            case Command.Inventory:
                Game.screen.DisplayScreen(ScreenType.Inventory);
                break;
            case Command.Interact:
                Game.NextStage();
                break;
            default:
                break;
        }
    }
}

