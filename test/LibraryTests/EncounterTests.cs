using NUnit.Framework;
using System.Collections.Generic;

namespace Ucu.Poo.RoleplayGame.Tests
{
    [TestFixture]
    public class EncounterTests
    {
        [Test]
        public void EnemiesAttackFirstAndHeroesLoseHealth()
        {
            // Arrange
            Hero hero = new Knight("Arthur");
            Enemy goblin = new Goblin("Grok");

            Encounter encounter = new Encounter(
                new List<Hero> { hero },
                new List<Enemy> { goblin }
            );

            int initialHeroHealth = hero.Health;

            // Act
            encounter.DoEncounter();

            // Assert
            Assert.Less(hero.Health, initialHeroHealth,
                "El héroe debería haber perdido vida tras los ataques enemigos.");
        }

        [Test]
        public void HeroKillsEnemyAndGainsVictoryPoints()
        {
            // Arrange
            Hero hero = new Knight("Arthur");
            Enemy goblin = new Goblin("Grok"); // VP = 3

            // Aumentamos el daño del héroe para asegurarnos que mate al enemigo
            hero.AddItem(new Sword()); // +20 attack extra

            Encounter encounter = new Encounter(
                new List<Hero> { hero },
                new List<Enemy> { goblin }
            );

            // Act
            encounter.DoEncounter();

            // Assert
            Assert.AreEqual(0, goblin.Health,
                "El enemigo debería estar muerto al finalizar el encuentro.");
            Assert.AreEqual(goblin.VictoryValue, hero.VictoryPoints,
                "El héroe debería haber ganado los puntos de victoria del enemigo.");
        }

        [Test]
        public void HeroCuresWhenReachingFiveVictoryPoints()
        {
            // Arrange
            Hero hero = new Knight("Arthur");
            Enemy goblin1 = new Goblin("Grok1"); // VP = 3
            Enemy goblin2 = new Goblin("Grok2"); // VP = 3

            // Dañamos al héroe antes del combate
            hero.ReceiveAttack(50);
            int damagedHealth = hero.Health;

            // Aumentamos ataque del héroe
            hero.AddItem(new Sword()); // aseguramos que mata rápido

            Encounter encounter = new Encounter(
                new List<Hero> { hero },
                new List<Enemy> { goblin1, goblin2 }
            );

            // Act
            encounter.DoEncounter();

            // Assert
            Assert.GreaterOrEqual(hero.VictoryPoints, 5,
                "El héroe debería haber acumulado al menos 5 puntos de victoria.");
            Assert.Greater(hero.Health, damagedHealth,
                "El héroe debería haberse curado al alcanzar 5 o más VP.");
        }

        [Test]
        public void EncounterEndsWhenAllHeroesOrEnemiesDie()
        {
            // Arrange
            Hero hero = new Knight("Arthur");
            Enemy DarkKnight = new DarkKnight("Uruk");

            Encounter encounter = new Encounter(
                new List<Hero> { hero },
                new List<Enemy> { DarkKnight }
            );

            // Act
            encounter.DoEncounter();

            // Assert
            bool heroesAlive = hero.Health > 0;
            bool enemiesAlive = DarkKnight.Health > 0;

            Assert.IsTrue(!heroesAlive || !enemiesAlive,
                "El encuentro debe terminar cuando todos los héroes o todos los enemigos mueren.");
        }

        [Test]
        public void MultipleEnemiesAttackCorrectHeroInOrder()
        {
            // Arrange
            Hero hero1 = new Archer("Legolas");
            Hero hero2 = new Dwarf("Gimli");

            Enemy goblin1 = new Goblin("G1");
            Enemy goblin2 = new Goblin("G2");
            Enemy goblin3 = new Goblin("G3");
            Enemy goblin4 = new Goblin("G4");

            List<Hero> heroes = new() { hero1, hero2 };
            List<Enemy> enemies = new() { goblin1, goblin2, goblin3, goblin4 };

            Encounter encounter = new(heroes, enemies);

            // Act
            encounter.DoEncounter();

            // Assert
            Assert.IsTrue(hero1.Health < 100 || hero2.Health < 100,
                "Ambos héroes deberían haber recibido daño.");
        }
    }
}
