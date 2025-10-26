using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests
{
    public class GoblinTests
    {
        private Goblin goblin;

        [SetUp]
        public void Setup()
        {
            goblin = new Goblin("Grok");
        }

        [Test]
        public void Goblin_TieneValorDeVictoriaPredeterminado()
        {
            Assert.That(goblin.VictoryValue, Is.EqualTo(3));
        }

        [Test]
        public void Goblin_TieneAtaqueYDefensaInicialPorSusItems()
        {
            Assert.That(goblin.AttackValue, Is.GreaterThan(0));
            Assert.That(goblin.DefenseValue, Is.GreaterThan(0));
        }

        [Test]
        public void Goblin_PierdeVidaAlSerAtacado()
        {
            int saludInicial = goblin.Health;
            goblin.ReceiveAttack(100);
            Assert.That(goblin.Health, Is.LessThan(saludInicial));
        }

        [Test]
        public void Goblin_SeCuraCorrectamente()
        {
            goblin.ReceiveAttack(50);
            int saludTrasAtaque = goblin.Health;
            goblin.Cure();
            Assert.That(goblin.Health, Is.EqualTo(100));
            Assert.That(goblin.Health, Is.GreaterThan(saludTrasAtaque));
        }
    }
}