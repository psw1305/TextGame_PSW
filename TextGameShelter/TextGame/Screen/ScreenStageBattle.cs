using Shelter.Core;
using Shelter.Model;

namespace Shelter.Screen;

public class ScreenStageBattle : IScreen
{
    static int selectionIdx = 0;
    static List<Enemy> enemies = Game.GetEnemies().ToList();

    static void Attack()
    {
        enemies[selectionIdx].Damaged(Game.Player.Atk);
        
        for (int i = 0; i < enemies.Count; i++)
        {
            Game.Player.Damaged(enemies[i].Atk);
        }
    }

    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Renderer.DrawBorder();
            Renderer.DrawSideBorder();
            Renderer.Print(4, "[ 전 투 ]");
            Renderer.DrawEnemies(8, selectionIdx, enemies);
            Renderer.PrintKeyGuide("[A] 공격  [E] 아이템 사용");
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
            ConsoleKey.A => Command.Attack,
            ConsoleKey.E => Command.Use,
            ConsoleKey.I => Command.Inventory,
            ConsoleKey.Enter => Command.Interact,
            _ => Command.Nothing
        };

        OnCommand(commands);
        return commands != Command.Use;
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
                if (selectionIdx < 2)
                    selectionIdx++;
                break;
            case Command.Attack:
                Attack();
                break;
            case Command.Use:
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
