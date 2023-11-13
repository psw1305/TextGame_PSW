using Shelter.Core;

namespace Shelter.Screen;

public class ScreenStageStart : IScreen
{
    static int progress = 0;
    static int selectionIdx = 0;
    static string[] selectionsCharacter =
    {
        "    빌    ",
        "  루이스  ",
        "   조이   ",
        " 프란시스 ",
    };

    static string[] selectionsStory =
    {
        "돈많은 부자",
        "은둔 외톨이",
        "생존형 전문가",
        "가진게 없는자",
    };

    static void Progress()
    {
        if (progress == 0)
        {
            Renderer.Print(4, "[캐릭터를 고르십시오..]");
            Renderer.PrintSelections(8, selectionIdx, selectionsCharacter);
        }
        else if (progress == 1)
        {
            Renderer.Print(4, "[이야기를 고르십시오..]");
            Renderer.PrintSelections(8, selectionIdx, selectionsStory);
            Renderer.PrintSideCharacterInfo();
        }
        else if (progress == 2)
        {
            Renderer.Print(4, "[쉘터 찾기...]");
            Renderer.Print(8, "[Enter를 눌러서 게임 스타트]");
            Renderer.PrintSideCharacterInfo();
            Renderer.PrintSideInventory();
        }
        else if (progress == 3)
        {
            Game.NextStage();
        }
    }

    static void Select()
    {
        progress++;

        if (progress == 1)
        {
            Game.Player = Game.Characters[selectionIdx];
        }
        else if (progress == 2)
        {
            switch (selectionIdx) 
            {
                case 0:
                    Game.Player.Cash = 10000;
                    Game.Player.Inventory = Game.Items_1.ToList();
                    break;
                case 1:
                    Game.Player.Cash = 3000;
                    Game.Player.Inventory = Game.Items_2.ToList();
                    break;
                case 2:
                    Game.Player.Cash = 5000;
                    Game.Player.Inventory = Game.Items_3.ToList();
                    break;
                case 3:
                    Game.Player.Cash = 0;
                    Game.Player.Inventory = new();
                    break;
            }
        }

        selectionIdx = 0;
    }

    public void DrawScreen()
    {
        do
        {
            Console.Clear();
            Renderer.DrawBorder();
            Renderer.DrawSideBorder();

            Progress();
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

        return commands != Command.Exit;
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
                if (selectionIdx < selectionsCharacter.Length - 1)
                    selectionIdx++;
                break;
            case Command.Interact:
                Select();
                break;
            default:
                break;
        }
    }
}
