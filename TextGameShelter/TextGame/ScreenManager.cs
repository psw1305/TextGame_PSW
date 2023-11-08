namespace Shelter;

public class ScreenManager
{
    public void Display()
    {

    }
}

/// <summary>
/// 씬 화면 타입
/// </summary>
public enum ScreenType
{
    Lobby,
    Main,
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

