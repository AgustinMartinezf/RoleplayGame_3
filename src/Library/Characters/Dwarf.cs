namespace Ucu.Poo.RoleplayGame;

public class Dwarf : Character, ICharacter
{
    public Dwarf(string name) : base(name)
    {
        this.AddItem(new Axe());
        this.AddItem(new Helmet());
    }
}
 
