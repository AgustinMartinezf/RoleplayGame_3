namespace Ucu.Poo.RoleplayGame
{
    public class VillainArcher : Enemy
    {
        public VillainArcher(string name) : base(name, 3) 
        {
            this.AddItem(new Bow());
            this.AddItem(new Helmet());
        }
    }
}
