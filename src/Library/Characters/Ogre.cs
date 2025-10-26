namespace Ucu.Poo.RoleplayGame
{
    public class Ogre : Enemy
    {
        public Ogre(string name) : base(name, 6)
        {
            AddItem(new Armor());
            AddItem(new Axe());
        }
    }
}