using Shelter.Core;

namespace Shelter.Screen;

public class ScreenEnd : IScreen
{
    public static int selectionIdx = 0;
    public static string[] selections =
    {
        "메 인 화 면",
    };

    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Renderer.DrawBorder();
            Renderer.DrawSideBorder();
            Renderer.Print(4, "[ 엔 딩 ]");
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
                Game.screen.DisplayScreen(ScreenType.Main);
                break;

            default:
                break;
        }
    }
}
