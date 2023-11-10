namespace Shelter.Screen;

public class ScreenEnd : IScreen
{
    public static int currentIdx = 0;
    public static string[] selections =
    {
        "메 인 화 면",
    };

    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("게임 끝");
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
            Console.WriteLine("[Enter: 선택]");
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
                Game.screen.DisplayScreen(ScreenType.Main);
                break;

            default:
                break;
        }
    }
}
