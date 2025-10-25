namespace Ucu.Poo.RoleplayGame
{
    public class DarkKnight : Enemy  // DarkKnight hereda de Enemy
    {
        public DarkKnight(string name) : base(name, 1)
        {
            this.AddItem(new Sword());  // Creo una espada para el DarkKnight
            this.AddItem(new Armor());  // Creo una armadura para el DarkKnight
        }
    }
}