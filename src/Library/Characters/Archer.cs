namespace Ucu.Poo.RoleplayGame;

public class Archer : Hero
{
    public Archer(string name) : base(name)
    {
        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }
}
