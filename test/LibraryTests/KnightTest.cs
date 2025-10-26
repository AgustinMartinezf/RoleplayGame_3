using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests
{
    public class KnightTests
    {
        private Knight caballero;

        [SetUp]
        public void Setup()
        {
            caballero = new Knight("Lancelot");
        }

        [Test]
        public void Caballero_IniciaConItemsBasicos()
        {
            Assert.That(caballero.AttackValue, Is.GreaterThan(0));
            Assert.That(caballero.DefenseValue, Is.GreaterThan(0));
        }
        
        [Test]
        public void Caballero_PierdeVidaMinimaSiElAtaqueNoSuperaLaDefensa()
        {
            int saludInicial = caballero.Health;
            caballero.ReceiveAttack(caballero.DefenseValue - 10);

            // Debería perder exactamente 1 punto por el daño mínimo garantizado
            Assert.That(caballero.Health, Is.EqualTo(saludInicial - 1));
        }


        [Test]
        public void Caballero_PierdeVidaSiAtaqueSuperaDefensa()
        {
            int saludInicial = caballero.Health;
            caballero.ReceiveAttack(caballero.DefenseValue + 50);
            Assert.That(caballero.Health, Is.LessThan(saludInicial));
        }

        [Test]
        public void Caballero_PuedeCurarse()
        {
            caballero.ReceiveAttack(80);
            int saludTrasAtaque = caballero.Health;
            caballero.Cure();
            Assert.That(caballero.Health, Is.EqualTo(100));
            Assert.That(caballero.Health, Is.GreaterThan(saludTrasAtaque));
        }
    }
}

