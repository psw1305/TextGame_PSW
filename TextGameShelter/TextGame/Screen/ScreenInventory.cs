using Shelter.Core;

namespace Shelter.Screen;

public class ScreenInventory
{
    // 인벤토리 정보 표시
    public static void DisplayInventory()
    {
        Console.Clear();

        Console.WriteLine("[인벤토리]");
        Console.WriteLine();

        // 아이템 목록 표시
        GameManager.player.DisplayInventoryList();

        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");

        int input = Extensions.CheckValidInput(0, 1);
        switch (input)
        {
            case 1:
                ScreenEquipment.DisplayEquipment();
                break;
            case 0:
                GameManager.DisplayGameIntro();
                break;
        }
    }
}
