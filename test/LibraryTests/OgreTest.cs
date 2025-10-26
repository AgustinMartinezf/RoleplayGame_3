using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests
{
    public class OgreTest
    {
        private Ogre ogre;

        [SetUp]
        public void Setup()
        {
            ogre = new Ogre("Grond");
        }

        [Test]
        public void Ogre_DeberiaTenerVictoryValueSeis()
        {
            Assert.That(ogre.VictoryValue, Is.EqualTo(6));
        }

        [Test]
        public void Ogre_AttackYDefenseSonMayoresQueCero()
        {
            Assert.That(ogre.AttackValue, Is.GreaterThan(0));
            Assert.That(ogre.DefenseValue, Is.GreaterThan(0));
        }

        [Test]
        public void Ogre_RecibirAtaqueNoReduceVidaNegativa()
        {
            int dano = 200; // daño mayor que la vida
            ogre.ReceiveAttack(dano);
            Assert.That(ogre.Health, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void Ogre_Cure_RestauraTodaLaVida()
        {
            ogre.ReceiveAttack(30);
            int vidaTrasAtaque = ogre.Health;

            ogre.Cure();

            Assert.That(ogre.Health, Is.EqualTo(100));
            Assert.That(ogre.Health, Is.GreaterThan(vidaTrasAtaque));
        }
    }