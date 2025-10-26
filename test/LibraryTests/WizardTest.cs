using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests
{
    public class WizardTests
    {
        private Wizard mago;

        [SetUp]
        public void Setup()
        {
            mago = new Wizard("Merlin");
        }

        [Test]
        public void Mago_IniciaConBaston()
        {
            Assert.That(mago.AttackValue, Is.GreaterThan(0));
            Assert.That(mago.DefenseValue, Is.GreaterThan(0));
        }

        [Test]
        public void Mago_PuedeAgregarItemMagico()
        {
            SpellsBook libro = new SpellsBook();
            libro.AddSpell(new SpellOne());
            mago.AddItem(libro);

            Assert.That(mago.AttackValue, Is.GreaterThan(100));
            Assert.That(mago.DefenseValue, Is.GreaterThan(100));
        }

        [Test]
        public void Mago_PuedeAgregarItemNoMagico()
        {
            Helmet casco = new Helmet();
            mago.AddItem(casco);

            Assert.That(mago.DefenseValue, Is.GreaterThan(100),
                "El mago debería aumentar su defensa al agregar un casco.");
        }

        [Test]
        public void Mago_PuedeCurarse()
        {
            mago.ReceiveAttack(50);
            int saludTrasAtaque = mago.Health;
            mago.Cure();
            Assert.That(mago.Health, Is.EqualTo(100));
            Assert.That(mago.Health, Is.GreaterThan(saludTrasAtaque));
        }
    }
}

