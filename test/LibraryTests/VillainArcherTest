using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace  Ucu.Poo.RoleplayGame.Tests
{
    [TestFixture]
    public class VillainArcherTests
    {
        [Test]
        public void VillainArcher_ShouldHaveDefaultItems()
        {
            VillainArcher villain = new VillainArcher("Sombra Oscura");

            // Debe tener el Bow y el Helmet
            Assert.That(villain.AttackValue, Is.GreaterThan(0));
            Assert.That(villain.DefenseValue, Is.GreaterThan(0));
        }

        [Test]
        public void VillainArcher_ShouldHaveVictoryValueOfThree()
        {
            VillainArcher villain = new VillainArcher("Sombra Oscura");
            Assert.That(villain.VictoryValue, Is.EqualTo(3));
        }

        [Test]
        public void VillainArcher_ShouldLoseHealthWhenAttacked()
        {
            VillainArcher villain = new VillainArcher("Sombra Oscura");
            int initialHealth = villain.Health;

            villain.ReceiveAttack(40);
            Assert.That(villain.Health, Is.LessThan(initialHealth));
        }

        [Test]
        public void VillainArcher_ShouldDieWhenHealthReachesZero()
        {
            VillainArcher villain = new VillainArcher("Sombra Oscura");
            villain.ReceiveAttack(999);
            Assert.That(villain.Health, Is.EqualTo(0));
        }
    }
}
