using Shelter.Model;
using Shelter.Model.Item;
using System.Text;
using static System.Console;

namespace Shelter.Core;

public static class Renderer
{
    private static int width;
    private static int height;

    private static int sideWidth;

    private static int GetPrintingLength(string line) => line.Sum(c => IsKorean(c) ? 2 : 1);
    private static bool IsKorean(char c) => '가' < c && c <= '힣';

    public static void Initialize()
    {
        Title = "SHELTER";
        ForegroundColor = ConsoleColor.White;
        Clear();
        OutputEncoding = Encoding.UTF8;
        CursorVisible = false;

        // 콘솔 사이즈 수정
        width = 70;
        height = 30;
        sideWidth = 30;

        WindowWidth = width + sideWidth;
        WindowHeight = height;
    }

    public static void DrawBorder()
    {
        SetCursorPosition(0, 0);
        Write("┌" + new string('─', width - 2) + "┐");

        for (int i = 1; i < height - 2; i++)
        {
            SetCursorPosition(0, i);
            Write("│" + new string(' ', width - 2) + "│");
        }

        SetCursorPosition(0, height - 2);
        Write("└" + new string('─', width - 2) + "┘");
    }

    public static void DrawSideBorder()
    {
        SetCursorPosition(width, 0);
        Write(new string('─', sideWidth - 2) + "┐");

        for (int i = 1; i < height - 2; i++)
        {
            SetCursorPosition(width, i);
            Write(new string(' ', sideWidth - 2) + "│");
        }

        SetCursorPosition(width, height - 2);
        Write(new string('─', sideWidth - 2) + "┘");
    }

    #region Title Print

    /// <summary>
    /// 메인 화면 가운데 출력
    /// </summary>
    /// <param name="content"></param>
    public static void PrintMain(int line, string content)
    {
        int correctLength = GetPrintingLength(content);
        SetCursorPosition((WindowWidth - correctLength) / 2, line);
        WriteLine(content);
    }

    /// <summary>
    /// 메인 화면 제목 출력
    /// </summary>
    public static void PrintMainTitle()
    {
        string[] title = Globals.ASCIIART_TITLE;
        int line = 4;

        for (int i = 0; i < title.Length; i++)
        {
            PrintMain(line + i, title[i]);
        }
    }


    /// <summary>
    /// 메인 화면 선택지 출력
    /// </summary>
    public static void PrintMainSelections(int index, string[] selections)
    {
        int line = height / 2;

        for (int i = 0; i < selections.Length; i++)
        {
            if (i == index)
            {
                PrintMain(line + (i * 2), $"▶ {selections[i]}");
            }
            else
            {
                PrintMain(line + (i * 2), $"   {selections[i]}");
            }
        }
    }

    #endregion

    #region Main Print

    /// <summary>
    /// 게임 화면 글자 출력 (왼쪽)
    /// </summary>
    public static void Print(int line, string content)
    {
        int correctLength = GetPrintingLength(content);
        SetCursorPosition((width - correctLength) / 2, line);
        WriteLine(content);
    }

    /// <summary>
    /// 게임 화면 선택지 출력
    /// </summary>
    public static void PrintSelections(int line, int index, string[] selections)
    {
        for (int i = 0; i < selections.Length; i++)
        {
            if (i == index)
            {
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.White;
                Print(line + (i * 2), $"{selections[i]}");
                ForegroundColor = ConsoleColor.White;
                BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Print(line + (i * 2), $"{selections[i]}");
            }
        }
    }

    /// <summary>
    /// 조작 가이드 출력
    /// </summary>
    public static void PrintKeyGuide(string content)
    {
        int line = height - 3;
        Print(line, content);
    }

    #endregion

    #region Side Print

    /// <summary>
    /// 게임 화면 글자 출력
    /// </summary>
    /// <param name="content"></param>
    public static void PrintSide(int line, string content)
    {
        SetCursorPosition(width + 2, line);
        WriteLine(content);
    }

    /// <summary>
    /// 게임 화면 선택지 출력
    /// </summary>
    /// <param name="content"></param>
    public static void PrintSideSelections(int line, int index, string[] selections)
    {
        for (int i = 0; i < selections.Length; i++)
        {
            if (i == index)
            {
                Print(line + i, $"{selections[i]}");
            }
            else
            {
                Print(line + i, $"{selections[i]}");
            }
        }
    }

    public static void PrintSideCharacterInfo()
    {
        Character player = Game.Player;

        PrintSide(1, $"[ 플 레 이 어 ]");
        PrintSide(3, $" 이 름 : {player.Name}");
        PrintSide(4, $" 직 업 : {player.Job}");
        PrintSide(5, $" 체 력 : {player.Hp}");
        PrintSide(6, $" 공 격 : {player.Atk}");
        PrintSide(7, $" 방 어 : {player.Def}");
        PrintSide(8, $" 명 중 : {player.Acc}");
        PrintSide(9, $" 회 피 : {player.Eva}");
    }

    public static void PrintSideInventory()
    {
        Character player = Game.Player;

        PrintSide(11, $"[ 인 벤 토 리 ] - {player.Cash}$");    
        for (int i = 0; i < player.Inventory.Count; i++)
        {
            if (player.Inventory[i].ItemType == ItemType.Equipment)
            {
                var equipItem = player.Inventory[i] as ItemEquip;

                if (equipItem.IsEquipped)
                {
                    PrintSide(13 + i, $"[장착] {equipItem.Name}");
                }
                else
                {
                    PrintSide(13 + i, $"{player.Inventory[i].Name}");
                }
            }
            else
            {
                PrintSide(13 + i, $"{player.Inventory[i].Name}");
            }
        }
    }

    public static void PrintSideAll()
    {
        PrintSideCharacterInfo();
        PrintSideInventory();
        PrintSide(height - 3, "[I] 인벤토리 확인");
    }

    #endregion

    #region Draw Battle

    /// <summary>
    /// 전투 중인 적 출력
    /// </summary>
    public static void DrawEnemies(int line, int index, List<Enemy> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (i == index)
            {
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.White;
                Print(line + (i * 2), $"{enemies[i].Name} [HP: {enemies[i].Hp}]");
                ForegroundColor = ConsoleColor.White;
                BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Print(line + (i * 2), $"{enemies[i].Name} [HP: {enemies[i].Hp}]");
            }
        }
    }

    #endregion
}
