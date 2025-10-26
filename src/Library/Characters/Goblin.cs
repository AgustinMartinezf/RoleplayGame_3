namespace Ucu.Poo.RoleplayGame;

public class Goblin : Enemy
{
    public Goblin(string name) : base(name, 3)
    {
        AddItem(new Axe());
        AddItem(new Helmet());
    }
}