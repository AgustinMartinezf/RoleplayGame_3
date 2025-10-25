namespace Ucu.Poo.RoleplayGame
{
    public class Encounter
    {
        public void DoEncounter(Hero hero, Enemy enemy)  // Ya recibe hero y enemy como parametro de la función, no es necesario un constructor
        {
            while (hero.Health > 0 && enemy.Health > 0)  // Mientras que el héroe y el enemigo sigan con vida...
            {
                enemy.ReceiveAttack(hero.AttackValue);  // El enemigo ataca al héroe
                if (enemy.Health == 0)  
                {
                    hero.AddVictoryPoints(enemy.VictoryPoints);  // Si el héroe vence al enemigo, este obtiene sus VP
                    break; 
                }
                hero.ReceiveAttack(enemy.AttackValue);  // El héroe ataca al enemigo 
            }
        }
    }
}