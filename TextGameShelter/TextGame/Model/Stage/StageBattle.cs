using System.Net;

namespace Shelter.Model.Stage;

public class StageBattle : IStage
{
    public StageType StageType { get; }
    public string Name { get; }
    public string Desc { get; }
    public Enemy[] Enemies { get; }

    public StageBattle(string name, string desc, Enemy[] enemies, StageType stageType = StageType.Battle)
    {
        Name = name;
        Desc = desc;
        Enemies = enemies;
        StageType = stageType;
    }
}
