using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests
{
    public class ArcherTests
    {
        private Archer arquero;

        [SetUp]
        public void Setup()
        {
            arquero = new Archer("Robin");
        }

        [Test]
        public void Arquero_TieneAtaqueYDefensaInicialPorSusItems()
        {
            Assert.That(arquero.AttackValue, Is.GreaterThan(0));
            Assert.That(arquero.DefenseValue, Is.GreaterThan(0));
        }

        [Test]
        public void Arquero_PierdeVidaAlRecibirAtaqueMayorASuDefensa()
        {
            int saludInicial = arquero.Health;
            arquero.ReceiveAttack(200);
            Assert.That(arquero.Health, Is.LessThan(saludInicial));
        }

        [Test]
        public void Arquero_SeCuraCorrectamente()
        {
            arquero.ReceiveAttack(50);
            int saludTrasAtaque = arquero.Health;
            arquero.Cure();
            Assert.That(arquero.Health, Is.EqualTo(100));
            Assert.That(arquero.Health, Is.GreaterThan(saludTrasAtaque));
        }
    }
}