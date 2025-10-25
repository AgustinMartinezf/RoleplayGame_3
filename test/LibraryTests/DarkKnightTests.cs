using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace Ucu.Poo.RoleplayGame.Tests
{
    [TestFixture]
    public class DarkKnightTests
    {
        [Test]
        public void DarkKnight_HasCorrectNameAndVP()
        {
            DarkKnight dk = new DarkKnight("Caballero Oscuro");  // Creo un DarkKnight y lo llamo "Caballero oscuro"
            
            Assert.That(dk.Name, Is.EqualTo("Caballero Oscuro"));  // Verifica que el nombre del DarkKnight sea "Caballero Oscuro"
            Assert.That(dk.VictoryPoints, Is.EqualTo(1));   // Verifica que el DarkKnight tenga un VP
            Assert.That(dk.Health, Is.EqualTo(100));  // Verifica que la salud de DarkKnight sea de 100 puntos 
        }
    }
}