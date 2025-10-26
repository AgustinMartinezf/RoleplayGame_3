namespace Ucu.Poo.RoleplayGame
{
    public class Enemy : Character  // Enemy hereda de character 
    {
        public int VictoryPoints { get; set; }

        public Enemy(string name, int victorypoints) : base(name)  // Inicializo el constructor 
        {
            this.VictoryPoints = victorypoints;
        }
    }
}