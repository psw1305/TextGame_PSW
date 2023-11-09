namespace Shelter.Screen;

public class ScreenStageStart : IScreen
{
    public static int currentIdx = 0;
    public static string[] selectNames =
    {
        "진 행 하 기",
    };

    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("시 작 스 테 이 지");
            Console.WriteLine();

            for (int i = 0; i < selectNames.Length; i++)
            {
                if (i == currentIdx)
                {
                    Console.WriteLine($"▷ {selectNames[i]}");
                }
                else
                {
                    Console.WriteLine($"   {selectNames[i]}");
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
                if (currentIdx < selectNames.Length - 1)
                    currentIdx++;
                break;
            case Command.Interact:
                Game.NextStage();
                break;
            default:
                break;
        }
    }
}
