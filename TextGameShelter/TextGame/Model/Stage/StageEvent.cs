namespace Shelter.Model.Stage;

public class StageEvent : IStage
{
    public StageType StageType { get; }
    public string Name { get; }
    public string Desc { get; }

    public StageEvent(string name, string desc, StageType stageType = StageType.Event)
    {
        Name = name;
        Desc = desc;
        StageType = stageType;
    }
}
