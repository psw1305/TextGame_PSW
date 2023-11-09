namespace Shelter.Screen;

public class ScreenMyInfo : IScreen
{
    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("[ 상 태 보 기 ]");
            Console.WriteLine();
            Console.WriteLine($"{Game.player.Name} ( {Game.player.Job} )");
            Console.WriteLine($"공격력 :{Game.player.Atk}");
            Console.WriteLine($"방어력 : {Game.player.Def}");
            Console.WriteLine($"체력  : {Game.player.Hp}");
            Console.WriteLine($"현금  : {Game.player.Cash}");
            Console.WriteLine();
            Console.WriteLine("[Esc: 나가기]");
        }
        while (ManageInput());
    }

    public bool ManageInput()
    {
        var key = Console.ReadKey(true);

        var commands = key.Key switch
        {
            ConsoleKey.Escape => Command.Exit,
            _ => Command.Nothing
        };

        if (commands == Command.Exit)
        {
            Game.screen.DisplayScreen(ScreenType.Main);
        }

        return commands != Command.Exit;
    }
}
