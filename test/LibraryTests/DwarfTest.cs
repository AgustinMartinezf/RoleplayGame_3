using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests
{
    public class DwarfTests
    {
        private Dwarf enano;

        [SetUp]
        public void Setup()
        {
            enano = new Dwarf("Gimli");
        }

        [Test]
        public void Enano_TieneAtaqueYDefensaInicialPorSusItems()
        {
            Assert.That(enano.AttackValue, Is.GreaterThan(0));
            Assert.That(enano.DefenseValue, Is.GreaterThan(0));
        }

        [Test]
        public void Enano_PierdeVidaAlRecibirAtaque()
        {
            int saludInicial = enano.Health;
            enano.ReceiveAttack(100);
            Assert.That(enano.Health, Is.LessThan(saludInicial));
        }

        [Test]
        public void Enano_PuedeCurarse()
        {
            enano.ReceiveAttack(70);
            int saludTrasAtaque = enano.Health;
            enano.Cure();
            Assert.That(enano.Health, Is.EqualTo(100));
            Assert.That(enano.Health, Is.GreaterThan(saludTrasAtaque));
        }
    }
}

