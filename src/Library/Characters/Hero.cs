namespace Ucu.Poo.RoleplayGame
{
    public class Hero : Character  // Hero hereda de character
    {
        public int VictoryPoints { get; set; }

        public Hero(string name) : base(name) {}  // Inicializo el constructor

        public void AddVictoryPoints(int victoryPoints)
        {
            this.VictoryPoints += victoryPoints;  // Incrementa los VP del héroe al derrotar enemigos
        }
    }
}