using Shelter.Core;
using Shelter.Model;

namespace Shelter.Screen;

public class Screen_Inventory
{
    // 인벤토리 정보 표시
    public static void DisplayInventory(Character player)
    {
        Console.Clear();

        Console.WriteLine("[ 인벤토리 ]");
        Console.WriteLine();

        // 아이템 목록 표시
        player.DisplayItems();

        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");

        int input = Extensions.CheckValidInput(0, 0);
        switch (input)
        {
            case 1:
                break;
            case 0:
                GameManager.DisplayGameIntro();
                break;
        }
    }
}
