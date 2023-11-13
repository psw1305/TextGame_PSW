using Shelter.Model.Stage;
using Shelter.Screen;

namespace Shelter;

public class ScreenManager
{
    /// <summary>
    /// 화면 타입 전시
    /// </summary>
    /// <param name="screenType"></param>
    public void DisplayScreen(ScreenType screenType)
    {
        IScreen screen = screenType switch
        {
            ScreenType.Main => new ScreenMain(),
            ScreenType.Inventory => new ScreenInventory(),
            ScreenType.Equipment => new ScreenEquipment(),
            ScreenType.Stage => new ScreenStageStart(),
            ScreenType.End => new ScreenEnd(),
            _ => new ScreenMain()
        };

        screen.DrawScreen();
    }

    /// <summary>
    /// 스테이지 타입에 따른 화면 전시
    /// </summary>
    /// <param name="stageType"></param>
    public void DisplayStageScreen(StageType stageType)
    {
        IScreen screen = stageType switch
        {
            StageType.Battle => new ScreenStageBattle(),
            StageType.Event => new ScreenStageEvent(),
            StageType.Shop => new ScreenStageShop(),
            _ => new ScreenMain()
        };

        screen.DrawScreen();
    }
}

/// <summary>
/// 씬 화면 타입
/// </summary>
public enum ScreenType
{
    Main,
    Inventory,
    Equipment,
    Stage,
    End,
}

/// <summary>
/// 콘솔 키 조작 타입
/// </summary>
public enum Command
{
    Exit,
    Interact,
    Nothing,
    MoveTop,
    MoveBottom,
    Attack,
    Use,
    Inventory,
    Num1,
    Num2,
    Num3,
}

