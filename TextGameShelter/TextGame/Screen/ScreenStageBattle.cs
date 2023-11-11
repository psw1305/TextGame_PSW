using Shelter.Core;
using Shelter.Model;

namespace Shelter.Screen;

public class ScreenStageBattle : IScreen
{
    static int selectedEnemyIdx;
    public static Enemy[] Enemies;

    public ScreenStageBattle() 
    {
        selectedEnemyIdx = 0;
        Enemies = Game.CurrentBattle().Enemies;
    }

    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Renderer.DrawBorder();
            Renderer.DrawSideBorder();
            Renderer.PrintSideCharacterInfo();
            Renderer.PrintSideInventory();
        }
        while (ManageInput());
    }

    public bool ManageInput()
    {
        var key = Console.ReadKey(true);

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
