namespace Ucu.Poo.RoleplayGame;

public class Knightt : Character
{
    public Knightt(string name) : base(name)
    {
        this.AddItem(new Sword());
        this.AddItem(new Shield());
        this.AddItem(new Armor());
    }
}

