using Shelter.Core;

namespace Shelter.Screen;

public class ScreenMain : IScreen
{
    public static int selectionIdx = 0;
    public static string[] selections =
    {
        "게 임 시 작",
        "이 어 하 기"
    };

    static ScreenType ScreenSelections()
    {
        return selectionIdx switch
        {
            0 => ScreenType.Stage,
            1 => ScreenType.Stage,
            _ => ScreenType.Main,
        };
    }

    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Renderer.PrintMainTitle();
            Renderer.PrintMainSelections(selectionIdx, selections);
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
                if (selectionIdx > 0)
                    selectionIdx--;
                break;
            case Command.MoveBottom:
                if (selectionIdx < selections.Length - 1)
                    selectionIdx++;
                break;
            case Command.Interact:
                Game.screen.DisplayScreen(ScreenSelections());
                break;
            default:
                break;
        }
    }
}
