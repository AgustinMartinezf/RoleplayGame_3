using System.Collections.Generic;

namespace Ucu.Poo.RoleplayGame;

public class Encounter
{
    private List<Hero> heroes;
    private List<Enemy> enemies;

    public Encounter(List<Hero> heroes, List<Enemy> enemies)
    {
        this.heroes = heroes;
        this.enemies = enemies;
    }

    public void DoEncounter()
    {
        while (heroes.Exists(h => h.Health > 0) && enemies.Exists(e => e.Health > 0))
        {
            // Enemigos atacan primero
            for (int i = 0; i < enemies.Count; i++)
            {
                var enemy = enemies[i];
                if (enemy.Health <= 0) continue;

                var hero = heroes[i % heroes.Count];
                if (hero.Health > 0)
                    hero.ReceiveAttack(enemy.AttackValue);
            }

            // Héroes atacan
            foreach (var hero in heroes)
            {
                if (hero.Health <= 0) continue;

                foreach (var enemy in enemies)
                {
                    if (enemy.Health <= 0) continue;

                    enemy.ReceiveAttack(hero.AttackValue);

                    if (enemy.Health == 0)
                        hero.AddVictoryPoints(enemy.VictoryValue);
                }
            }
        }
    }
}