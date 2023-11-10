namespace Shelter.Screen;

using Shelter.Model;
using static System.Console;

public class ScreenStageBattle : IScreen
{
    static int selectedEnemyIdx;

    public static Enemy[] Enemies;

    int spacing = 15;

    public ScreenStageBattle() 
    {
        selectedEnemyIdx = 0;
        Enemies = Game.CurrentBattle().Enemies;
    }

    public void DrawScreen()
    {
        do
        {
            Clear();
            WriteLine("전 투 스 테 이 지");
            WriteLine();

            for (int i = 0; i < 3; i++)
            {
                if (i == selectedEnemyIdx)
                {
                    Write("▽".PadRight(spacing));
                }
                else
                {
                    Write("  ".PadRight(spacing));
                }
            }

            WriteLine();
            WriteLine();
            WriteLine("[방향키 ← →: 좌우로 이동] [A: 공격] [E: 아이템 사용]");
        }
        while (ManageInput());
    }

    public bool ManageInput()
    {
        var key = ReadKey(true);

        var commands = key.Key switch
        {
            ConsoleKey.LeftArrow => Command.MoveLeft,
            ConsoleKey.RightArrow => Command.MoveRight,
            ConsoleKey.A => Command.Attack,
            ConsoleKey.E => Command.Use,
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
            case Command.MoveLeft:
                if (selectedEnemyIdx> 0)
                {
                    selectedEnemyIdx--;
                }
                break;
            case Command.MoveRight:
                if (selectedEnemyIdx < 2)
                {
                    selectedEnemyIdx++;
                }
                break;
            case Command.Attack:
                
                break;
            case Command.Use:
                
                break;
            case Command.Interact:
                Game.NextStage();
                break;
            default:
                break;
        }
    }
}
