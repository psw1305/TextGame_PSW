using Shelter.Core;
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
        Renderer.Initialize();
        screen.DisplayScreen(ScreenType.Main);
    }

    #region Player

    // 돈 많은 부자
    public static IItem[] Items_1 =
    {
        new ItemEquip(EquipType.Armor, "정장", "격식을 갖춘 옷차림", 1000, StatType.DEF, 3),
        new ItemEquip(EquipType.Weapon, "케이스형 가방", "단단한 재질의 가방", 1000, StatType.ATK, 4),
    };

    // 은둔형 외톨이
    public static IItem[] Items_2 =
    {
        new ItemEquip(EquipType.Armor, "별모양 안경", "꾸미기용 안경", 1000, StatType.ACC, 10),
        new ItemEquip(EquipType.Weapon, "일렉트릭 기타", "연주용 기타", 2000, StatType.ATK, 6),
        new ItemUseable("초코바", "요기용으로 괜찮습니다.", 50),
    };

    // 생존 전문가
    public static IItem[] Items_3 =
    {
        new ItemEquip(EquipType.Armor, "길리 슈트", "고성능 위장복", 5000, StatType.EVA, 20),
        new ItemEquip(EquipType.Weapon, "컴뱃 나이프", "전투용 단검", 1500, StatType.ATK, 8),
        new ItemUseable("전투 식량", "든든한 한끼", 500),
    };

    public static Equipment Equipment = new();

    public static Character[] Characters =
    {
        new("빌", "퇴역 군인", 100, 10, 1, 90, 10, Equipment),
        new("루이스", "회사원", 110, 9, 2, 95, 15, Equipment),
        new("조이", "학생", 80, 8, 0, 100, 20, Equipment),
        new("프란시스", "바이커", 120, 12, 3, 80, 0, Equipment)
    };

    public static Character Player { get; set; }

    #endregion

    #region Stage 

    private static int currentStage = -1;
    private static int battleIndex = -1;

    public static IStage[] Stages =
    {
        new StageBattle("스테이지 1", "첫번째 전투입니다."),
        new StageEvent("스테이지 2", "첫번째 이벤트입니다."),
        new StageBattle("스테이지 3", "두번째 전투입니다."),
        new StageShop("상점", "상점입니다."),
        new StageEvent("스테이지 4", "두번째 이벤트입니다."),
        new StageBattle("스테이지 5", "마지막 전투입니다.")
    };

    public static List<Enemy> GetEnemies()
    {
        battleIndex++;

        if (battleIndex == 0)
        {
            return Encounter1;
        }
        else if (battleIndex == 1)
        {
            return Encounter2;
        }
        else
        {
            return Encounter3;
        }
    }

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

    public static List<Enemy> Encounter1 = new()
    {
        new Enemy("시궁 쥐", 5, 0, 10),
        new Enemy("시궁 쥐", 5, 0, 10),
        new Enemy("시궁 쥐", 5, 0, 10)
    };

    public static List<Enemy> Encounter2 = new()
    {
        new Enemy("레이더", 8, 3, 30),
        new Enemy("레이더", 8, 3, 30)
    };

    public static List<Enemy> Encounter3 = new()
    {
        new Enemy("군용 드론", 20, 10, 80)
    };

    public static IItem[] ShopProducts =
    {
        new ItemEquip(EquipType.Armor, "소방서 방화복", "열내상이 좋은 복장", 1500, StatType.DEF, 10),
        new ItemEquip(EquipType.Armor, "경찰 진압복", "단단한 복장", 1500, StatType.DEF, 15),
        new ItemEquip(EquipType.Weapon, "마체테", "다용도 정글도", 500,  StatType.ATK, 10),
        new ItemEquip(EquipType.Weapon, "소방 도끼", "다재다능한 도끼", 800,  StatType.ATK, 12),
        new ItemUseable("권총", "단 한발 쏠 수 있음", 3000),
        new ItemUseable("붕대", "상처 치료에 효율", 200),
        new ItemUseable("과일 통조림", "간단 식료품", 150),
    };

    #endregion
}
