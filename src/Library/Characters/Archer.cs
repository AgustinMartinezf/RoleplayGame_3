namespace Ucu.Poo.RoleplayGame;

public class Archer : Character
{
    public Archer(string name) : base(name)
    {
        this.Name = name;

        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }
}