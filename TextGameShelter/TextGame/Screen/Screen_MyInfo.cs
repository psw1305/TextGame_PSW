using Shelter.Core;
using Shelter.Model;

namespace Shelter.Screen
{
    public class Screen_MyInfo
    {
        public static void DisplayMyInfo(Character player)
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
            Console.WriteLine($"병뚜껑 : {player.Cap} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = Extensions.CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    GameManager.DisplayGameIntro();
                    break;
            }
        }
    }
}
