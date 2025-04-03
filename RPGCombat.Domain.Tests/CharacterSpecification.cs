using FluentAssertions;

namespace RPGCombat.Domain.Tests
{
    public class CharacterSpecification
    {
        [Fact]
        public void Debe_permitir_crear_un_personaje_con_1000_puntos_de_vida_y_en_estado_vivo()
        {
            // Arrange
            var character = new Character();

            // Act
            var health = character.Health;
            var isAlive = character.IsAlive;

            // Assert
            health.Should().Be(1_000);
            isAlive.Should().BeTrue();
        }
    }

    public class Character
    {
        public int Health { get; private set; }
        public bool IsAlive { get; private set; }

        public Character()
        {
            Health = 1_000;
            IsAlive = true;
        }
    }
}
