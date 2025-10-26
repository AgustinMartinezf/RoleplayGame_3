namespace Ucu.Poo.RoleplayGame
{
    public class Troll : Enemy
    {
        public Troll(string name) : base(name, 7)
        {
            AddItem(new Armor());
            AddItem(new Axe());
        }
    }
}