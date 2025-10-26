namespace Ucu.Poo.RoleplayGame
{
    public class Hero : Character  // Hero hereda de character
    {
        public int VictoryPoints { get; private set; }

        public Hero(string name) : base(name) {}  // Inicializo el constructor

        public void AddVictoryPoints(int points)
        {
            this.VictoryPoints += points; // Incrementa los VP del héroe al derrotar enemigos
            if (this.VictoryPoints >= 5)
            {
                this.Cure(); // Se cura si llega a 5 o más VP
            }  
        }
    }
}