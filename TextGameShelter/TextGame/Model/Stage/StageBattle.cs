namespace Shelter.Model.Stage;

public class StageBattle : IStage
{
    public StageType StageType { get; }
    public string Name { get; }
    public string Desc { get; }
    public List<Enemy> Enemys { get; }

    public StageBattle(string name, string desc, StageType stageType = StageType.Battle)
    {
        Name = name;
        Desc = desc;
        StageType = stageType;
    }
}
