using Shelter.Core;

namespace Shelter.Screen
{
    public class ScreenMyInfo
    {
        public static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("[상태보기] - 캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{GameManager.player.Level}");
            Console.WriteLine($"{GameManager.player.Name} ( {GameManager.player.Job} )");
            Console.WriteLine($"공격력 :{GameManager.player.Atk}");
            Console.WriteLine($"방어력 : {GameManager.player.Def}");
            Console.WriteLine($"체력  : {GameManager.player.Hp}");
            Console.WriteLine($"현금  : {GameManager.player.Cash}");
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
