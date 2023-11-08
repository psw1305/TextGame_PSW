namespace Shelter.Screen;

public interface IScreen
{
    /// <summary>
    /// 화면 그리기
    /// </summary>
    public void DrawScreen();

    /// <summary>
    /// 화면 콘솔 조작
    /// </summary>
    public bool ManageInput();
}
