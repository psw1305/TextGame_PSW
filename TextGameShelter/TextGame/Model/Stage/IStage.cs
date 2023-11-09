namespace Shelter.Model.Stage;

public enum StageType
{
    Battle,
    Event,
    Shop,
}

public interface IStage
{
    public StageType StageType { get; }
    public string Name { get; }
    public string Desc { get; }
}
