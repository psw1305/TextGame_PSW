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

    #region Player
    
    public static IItem[] Items =
    {
        new ItemEquip(EquipType.Armor, "후줄근한 조끼", "없는 것 보다는 낫다", 500, 5),
        new ItemEquip(EquipType.Weapon, "야구 방망이", "흔한 스포츠 야구 방망이", 200, 2),
        new ItemUseable("초코바", "요기용으로 괜찮습니다.", 50),
    };

    public static Equipment Equipment = new();

    public static Character player = new("Bill", "퇴역 군인", 10, 5, 100, 5000, Items.ToList(), Equipment);

    #endregion

    #region Stage 

    private static int currentStage = -1;

    public static IStage[] Stages =
    {
        new StageBattle("스테이지 1", "첫번째 전투입니다.", Encounter1),
        new StageEvent("스테이지 2", "첫번째 이벤트입니다."),
        new StageBattle("스테이지 3", "두번째 전투입니다.", Encounter2),
        new StageShop("상점", "첫번째 전투입니다."),
        new StageEvent("스테이지 4", "두번째 이벤트입니다."),
        new StageBattle("스테이지 5", "마지막 전투입니다.", Encounter3)
    };

    public static void InitStage()
    {
        currentStage = -1;
    }

    public static void CurrentStage()
    {
        screen.DisplayStageScreen(Stages[currentStage].StageType);
    }

    public static void NextStage()
    {
        if (currentStage < Stages.Length - 1)
        {
            currentStage++;
            CurrentStage();
        }
        else
        {
            InitStage();
            screen.DisplayScreen(ScreenType.End);
        }
    }

    #endregion

    #region Stage Data

    public static Enemy[] Encounter1 =
    {
        new Enemy("시궁 쥐", 4, 0, 25),
        new Enemy("거대한 벌레", 3, 2, 12),
    };

    public static Enemy[] Encounter2 =
    {
        new Enemy("레이더", 8, 3, 40),
    };

    public static Enemy[] Encounter3 =
    {
        new Enemy("군용 드론", 20, 10, 80)
    };

    public static IItem[] ShopProducts =
    {
        new ItemEquip(EquipType.Armor, "소방서 방화복", "뜨거운 온도를 견딜수 있습니다", 1500, 15),
        new ItemEquip(EquipType.Armor, "경찰 진압복", "신체를 보호하는 복장", 1500, 15),
        new ItemEquip(EquipType.Weapon, "마체테", "여러 용도에 쓰이는 정글도", 500, 4),
        new ItemEquip(EquipType.Weapon, "소방 도끼", "다재다능한 도구", 800, 8),
        new ItemUseable("권총", "총알 하나만 장전되어있습니다.", 3000),
        new ItemUseable("붕대", "다친 상처를 치료할 때 쓰입니다.", 200),
        new ItemUseable("과일 통조림", "허기를 채울 때 좋습니다.", 150),
    };

    #endregion
}
