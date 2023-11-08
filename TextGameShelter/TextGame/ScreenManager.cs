using Shelter.Screen;

namespace Shelter;

public class ScreenManager
{
    public void DisplayScreen(ScreenType screenType)
    {
        IScreen screen = screenType switch
        {
            ScreenType.Main => new ScreenMain(),
            ScreenType.MyInfo => new ScreenMyInfo(),
            ScreenType.Inventory => new ScreenInventory(),
            ScreenType.Equipment => new ScreenEquipment(),
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
    MyInfo,
    Inventory,
    Equipment,
}

public enum Command
{
    Exit,
    Interact,
    Nothing,
    MoveTop,
    MoveBottom,
}

