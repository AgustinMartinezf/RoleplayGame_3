using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace Ucu.Poo.RoleplayGame.Tests
{
    [TestFixture]
    public class EncounterTests
    {
        [Test]
        public void HeroDefeatsDarkKnightAndGetsVP()
        {
            Hero hero = new Hero("LightKnight");  // Creo un héroe y lo llamo "LightKnight"
            hero.AddItem(new Sword());  // Le creo una espada al héroe 

            DarkKnight darkKnight = new DarkKnight("Caballero Oscuro");  // Creo un DarkKnight y lo llamo "Caballero oscuro"
            
            Encounter encounter = new Encounter();  // Creo un encuentro en el que se enfrentan el héroe y el DarkKnight
            
            encounter.DoEncounter(hero, darkKnight);  // Combaten hasta que uno gane
            
            Assert.That(darkKnight.Health, Is.EqualTo(0)); // Verifica si el darkknight sigue con vida 
            Assert.That(hero.VictoryPoints, Is.EqualTo(darkKnight.VictoryPoints)); // Verifica si el héroe ganó los VP
            Assert.That(hero.Health, Is.GreaterThan(0)); // Verifica si el héroe murió
        }
    }
}