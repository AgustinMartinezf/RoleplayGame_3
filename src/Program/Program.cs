using System;
using System.Collections.Generic;
using Ucu.Poo.RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a los Encuentros de la Tierra Media \n");

            // Crear Héroes
            Hero legolas = new Archer("Legolas");
            Hero gimli = new Dwarf("Gimli");
            Hero arthur = new Knight("Arthur");
            Hero merlin = new Wizard("Merlin");

            // Crear Enemigos
            Enemy goblin = new Goblin("Grok");
            Enemy troll = new Troll("Uruk");

            // Crear listas de héroes y enemigos
            List<Hero> heroes = new List<Hero> { legolas, gimli, arthur, merlin };
            List<Enemy> enemies = new List<Enemy> { goblin, troll };

            // Mostrar estado inicial
            Console.WriteLine("Héroes iniciales:");
            foreach (var h in heroes)
                Console.WriteLine($"{h.Name} — HP: {h.Health}");

            Console.WriteLine("\nEnemigos iniciales:");
            foreach (var e in enemies)
                Console.WriteLine($"{e.Name} — HP: {e.Health}");

            Console.WriteLine("\n¡Comienza la batalla!\n");

            int round = 1;
            while (heroes.Exists(h => h.Health > 0) && enemies.Exists(e => e.Health > 0))
            {
                Console.WriteLine($"\n --- RONDA {round} ---");

                // Enemigos atacan
                for (int i = 0; i < enemies.Count; i++)
                {
                    var enemy = enemies[i];
                    if (enemy.Health <= 0) continue;

                    var hero = heroes[i % heroes.Count];
                    if (hero.Health > 0)
                    {
                        int daño = enemy.AttackValue - hero.DefenseValue;
                        if (daño <= 0) daño = 1;
                        hero.ReceiveAttack(enemy.AttackValue);
                        Console.WriteLine($" {enemy.Name} ataca a {hero.Name} causando {daño} de daño. HP de {hero.Name}: {hero.Health}");
                    }
                }

                // Héroes atacan
                foreach (var hero in heroes)
                {
                    if (hero.Health <= 0) continue;

                    foreach (var enemy in enemies)
                    {
                        if (enemy.Health <= 0) continue;

                        int daño = hero.AttackValue - enemy.DefenseValue;
                        if (daño <= 0) daño = 1;
                        enemy.ReceiveAttack(hero.AttackValue);
                        Console.WriteLine($" {hero.Name} ataca a {enemy.Name} causando {daño} de daño. HP de {enemy.Name}: {enemy.Health}");

                        if (enemy.Health == 0)
                        {
                            hero.AddVictoryPoints(enemy.VictoryValue);
                            Console.WriteLine($" {hero.Name} ha derrotado a {enemy.Name} y gana {enemy.VictoryValue} VP (total: {hero.VictoryPoints}).");
                            if (hero.VictoryPoints >= 5)
                            {
                                Console.WriteLine($" {hero.Name} alcanzó 5 VP y se cura completamente!");
                            }
                        }
                    }
                }

                // Mostrar resumen de la ronda
                Console.WriteLine("\n Estado tras la ronda:");
                foreach (var h in heroes)
                    Console.WriteLine($" {h.Name} — HP: {h.Health} — VP: {h.VictoryPoints}");

                foreach (var e in enemies)
                    Console.WriteLine($" {e.Name} — HP: {e.Health}");

                round++;
            }

            // Mostrar resultado final
            Console.WriteLine("\n --- RESULTADO FINAL ---");
            foreach (var h in heroes)
            {
                string estado = h.Health > 0 ? "VIVO" : "MUERTO";
                Console.WriteLine($" {h.Name} — HP: {h.Health} — VP: {h.VictoryPoints} — {estado}");
            }

            foreach (var e in enemies)
            {
                string estado = e.Health > 0 ? "VIVO" : "MUERTO";
                Console.WriteLine($" {e.Name} — HP: {e.Health} — VP: {e.VictoryValue} — {estado}");
            }

            Console.WriteLine("\n Fin del encuentro.");
        }
    }
}


