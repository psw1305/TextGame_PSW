namespace Shelter.Model.Stage;

public class StageShop : IStage
{
    public StageType StageType { get; }
    public string Name { get; }
    public string Desc { get; }

    public StageShop(string name, string desc, StageType stageType = StageType.Shop)
    {
        Name = name;
        Desc = desc;
        StageType = stageType;
    }
}