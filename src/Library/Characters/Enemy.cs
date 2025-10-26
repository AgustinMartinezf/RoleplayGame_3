namespace Ucu.Poo.RoleplayGame
{
    public class Enemy : Character  // Enemy hereda de character 
    {
        public int VictoryValue { get; protected set; }

        public Enemy(string name, int victoryValue) : base(name)  // Inicializo el constructor 
        {
            this.VictoryValue = victoryValue;
        }
    }
}