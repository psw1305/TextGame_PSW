namespace Shelter.Screen;

public class ScreenMyInfo : IScreen
{
    public void DrawScreen()
    {
        do
        {
            Console.Clear();

            Console.WriteLine("[상태보기]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{GameManager.player.Level}");
            Console.WriteLine($"{GameManager.player.Name} ( {GameManager.player.Job} )");
            Console.WriteLine($"공격력 :{GameManager.player.Atk}");
            Console.WriteLine($"방어력 : {GameManager.player.Def}");
            Console.WriteLine($"체력  : {GameManager.player.Hp}");
            Console.WriteLine($"현금  : {GameManager.player.Cash}");
            Console.WriteLine();
            Console.WriteLine("[Esc: 나가기]");
        }
        while (ManageInput());
    }

    public bool ManageInput()
    {
        var key = Console.ReadKey();

        var commands = key.Key switch
        {
            ConsoleKey.Escape => Command.Exit,
            _ => Command.Nothing
        };

        if (commands == Command.Exit)
        {
            GameManager.screen.DisplayScreen(ScreenType.Main);
        }

        return commands != Command.Exit;
    }
}
