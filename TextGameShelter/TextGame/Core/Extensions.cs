using Shelter.Model;

namespace Shelter.Core;

public static class Extensions
{
    public static bool IsEmptyItem(this IItem i) => string.IsNullOrEmpty(i.Name);

    /// <summary>
    /// 선택지 입력 체크
    /// </summary>
    public static int CheckValidInput(int min, int max)
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
