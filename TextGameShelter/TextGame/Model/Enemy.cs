namespace Shelter.Model;

public class Enemy
{
    public string Name { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }

    public Enemy(string name, int atk, int def, int hp)
    {
        Name = name;
        Atk = atk;
        Def = def;
        Hp = hp;
    }
}
