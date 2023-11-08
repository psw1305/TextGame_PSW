using Shelter.Core;
using Shelter.Model;
using Shelter.Screen;

namespace Shelter;

public class GameManager
{
    // 게임 시작
    public void Start()
    {
        DisplayGameIntro();
    }

    #region Player Setting
    
    public static IItem[] Items =
    {
        new ItemEquip("후줄근한 조끼", "없는 것 보다는 낫다", EquipType.Armor, 5),
        new ItemEquip("야구 방망이", "흔한 스포츠 야구 방망이", EquipType.Weapon, 2),
        new ItemEquip("경찰 진압복", "신체를 보호하는 복장", EquipType.Armor, 15),
        new ItemEquip("마체테", "여러 용도에 쓰이는 정글도", EquipType.Weapon, 4),
        new ItemEquip("소방도끼", "다재다능한 만능 도구", EquipType.Weapon, 8),
        new ItemEquip("소방서 방화복", "뜨거운 열에 내성이 있는 복장", EquipType.Armor, 11)
    };

    public static Equipment Equipment = new();

    public static Character player = new Character("John", "전직 군인", 1, 10, 5, 100, 1500, Items.ToList(), Equipment);

    #endregion

    public static void DisplayGameIntro()
    {
        Console.Clear();

        Console.WriteLine(Globals.ASCIIART_TITLE);

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
                ScreenMyInfo.DisplayMyInfo();
                break;
            case 2:
                ScreenInventory.DisplayInventory();
                break;
        }
    }
}
