using Shelter.Core;
using Shelter.Model;
using Shelter.Screen;

namespace Shelter;

public class GameManager
{
    private static Character player;

    public void Start()
    {
        GameDataSetting();
        DisplayGameIntro();
    }

    // 게임 데이터 세팅
    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅
        player = new Character("John", "전직 군인", 1, 10, 5, 100, 1500);

        // 아이템 정보 세팅

        player.Items.Add(new Item_Equip("찟어진 조끼", "없는 것 보다는 낫다", EquipType.Armor, 5));
        player.Items.Add(new Item_Equip("야구 방망이", "흔한 스포츠 야구 방망이", EquipType.Weapon, 2));
    }

    public static void DisplayGameIntro()
    {
        Console.Clear();

        Console.WriteLine(Globals.LobbyTitleAsciiArt);

        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 게임시작");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = Extensions.CheckValidInput(1, 2);
        switch (input)
        {
            case 1:
                Screen_MyInfo.DisplayMyInfo(player);
                break;

            case 2:
                Screen_Inventory.DisplayInventory(player);
                break;
        }
    }
}
