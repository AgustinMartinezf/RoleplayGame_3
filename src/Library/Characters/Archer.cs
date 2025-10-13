namespace Ucu.Poo.RoleplayGame;

public class Archer : Character, ICharacter
{
    public Archer(string name) : base(name)
    {
        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }
}
