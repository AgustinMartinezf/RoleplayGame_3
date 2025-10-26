using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests
{
    public class TrollTests
    {
        private Troll troll;

        [SetUp]
        public void Setup()
        {
            troll = new Troll("Borg");
        }

        [Test]
        public void Troll_VictoryValue_EsSiete()
        {
            Assert.That(troll.VictoryValue, Is.EqualTo(7));
        }

        [Test]
        public void Troll_TieneEstadisticasInicialesValidadas()
        {
            // Variante de nombre y de intención respecto a los tests del Goblin:
            // comprobamos que ataque y defensa iniciales son positivos.
            Assert.That(troll.AttackValue, Is.GreaterThan(0), "El valor de ataque debe ser mayor que 0");
            Assert.That(troll.DefenseValue, Is.GreaterThan(0), "El valor de defensa debe ser mayor que 0");
        }

        [Test]
        public void Troll_DefensaReduceElDanoRecibido()
        {
            // Comprobamos que la cantidad de vida perdida es menor que el daño bruto,
            // lo que indica que la defensa está mitigando parte del ataque.
            int vidaInicial = troll.Health;
            int dano = 30;
            troll.ReceiveAttack(dano);
            int perdida = vidaInicial - troll.Health;

            Assert.That(perdida, Is.LessThan(dano), "La defensa debería reducir parte del daño recibido");
            Assert.That(troll.Health, Is.GreaterThanOrEqualTo(0), "La vida no debería bajar a valores negativos");
        }

        [Test]
        public void Troll_Cure_RestauraVidaAlMaximo()
        {
            // Golpeamos, luego curamos y esperamos la salud completa (100).
            troll.ReceiveAttack(50);
            int vidaTrasAtaque = troll.Health;
            Assert.That(vidaTrasAtaque, Is.LessThan(100), "Tras el ataque la vida debe ser menor que la máxima");

            troll.Cure();
            Assert.That(troll.Health, Is.EqualTo(100), "Cure debe restaurar la vida a 100");
            Assert.That(troll.Health, Is.GreaterThan(vidaTrasAtaque), "La vida tras curarse debe ser mayor que la tras el ataque");
        }
    }
}