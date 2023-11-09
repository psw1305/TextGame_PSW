using Shelter.Model;
using Shelter.Model.Item;
using Shelter.Model.Stage;

namespace Shelter;

public class Game
{
    public static ScreenManager screen = new();

    // 게임 시작
    public void Start()
    {
        Console.CursorVisible = false;
        screen.DisplayScreen(ScreenType.Main);
    }

    #region Player Setting
    
    public static IItem[] Items =
    {
        new ItemEquip(EquipType.Armor, "후줄근한 조끼", "없는 것 보다는 낫다", 500, 5),
        new ItemEquip(EquipType.Weapon, "야구 방망이", "흔한 스포츠 야구 방망이", 200, 2),
        new ItemEquip(EquipType.Armor, "경찰 진압복", "신체를 보호하는 복장", 1500, 15),
        new ItemEquip(EquipType.Weapon, "마체테", "여러 용도에 쓰이는 정글도", 400, 4),
        new ItemUseable("과일 통조림", "허기를 채울 때 좋습니다.", 150),
        new ItemUseable("권총", "딱 총알 하나만 장전되어있습니다.", 3000),
        new ItemUseable("붕대", "다친 상처를 치료할 때 쓰입니다.", 500)
    };

    public static Equipment Equipment = new();

    public static Character player = new("John", "전직 군인", 10, 5, 100, 1500, Items.ToList(), Equipment);

    #endregion

    #region Stage Setting

    private static int currentStage = -1;

    public static IStage[] Stages =
    {
        new StageBattle("스테이지 1", "첫번째 전투입니다."),
        new StageEvent("스테이지 2", "첫번째 이벤트입니다."),
        new StageBattle("스테이지 3", "두번째 전투입니다."),
        new StageShop("상점", "첫번째 전투입니다."),
        new StageEvent("스테이지 4", "두번째 이벤트입니다."),
        new StageBattle("스테이지 5", "마지막 전투입니다.")
    };

    public static void NextStage()
    {
        if (currentStage < Stages.Length - 1)
        {
            currentStage++;
            screen.DisplayStageScreen(Stages[currentStage].StageType);
        }
        else
        {
            currentStage = -1;
            screen.DisplayScreen(ScreenType.End);
        }
    }

    #endregion
}
