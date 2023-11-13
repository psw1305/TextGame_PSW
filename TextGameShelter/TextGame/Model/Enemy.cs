namespace Shelter.Model;

public class Enemy
{
    public string Name { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; set; }

    public Enemy(string name, int atk, int def, int hp)
    {
        Name = name;
        Atk = atk;
        Def = def;
        Hp = hp;
    }

    public void Damaged(int damage)
    {
        if (damage <= Def) return;

        Hp -= damage;

        if (Hp <= 0)
        {
            Hp = 0;
        }
    }
}
