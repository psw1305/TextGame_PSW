using Shelter.Model;

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
        player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

        // 아이템 정보 세팅
    }

    static void DisplayGameIntro()
    {
        Console.Clear();

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(1, 2);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;

            case 2:
                DisplayInventory();
                break;
        }
    }

    // 자신의 스텟 정보 표시
    static void DisplayMyInfo()
    {
        Console.Clear();

        Console.WriteLine("[ 상태보기 ]");
        Console.WriteLine("캐릭터의 정보를 표시합니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Level}");
        Console.WriteLine($"{player.Name} ( {player.Job} )");
        Console.WriteLine($"공격력 :{player.Atk}");
        Console.WriteLine($"방어력 : {player.Def}");
        Console.WriteLine($"체력 : {player.Hp}");
        Console.WriteLine($"Gold : {player.Gold} G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }

    // 인벤토리 정보 표시
    static void DisplayInventory()
    {
        Console.Clear();

        Console.WriteLine("[ 인벤토리 ]");
        Console.WriteLine();

        // 아이템 목록 표시
        player.DisplayItems();

        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 1:
                DisplayEquipmentManage();
                break;
            case 0:
                DisplayGameIntro();
                break;
        }
    }

    static void DisplayEquipmentManage()
    {

    }

    static int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if (ret >= min && ret <= max)
                    return ret;
            }

            Console.WriteLine("잘못된 입력입니다.");
        }
    }
}
