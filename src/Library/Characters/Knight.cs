namespace Ucu.Poo.RoleplayGame
{
    public class Knight : Character, ICharacter
    {
        public Knight(string name) : base(name)
        {
            this.AddItem(new Sword());
            this.AddItem(new Shield());
            this.AddItem(new Armor());
        }
    }
}
