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
            var isAlive = character.IsAlive();

            // Assert
            health.Should().Be(1_000);
            isAlive.Should().BeTrue();
        }

        [Theory]
        [InlineData(100, 900), InlineData(800, 200)]
        public void Debe_un_personaje_infligir_daño_a_otro_personaje_y_reducir_su_vida_en_la_cantidad_del_daño(int damage, int defenderHealth)
        {
            // Arrange
            var attacker = new Character();
            var defender = new Character();

            // Act
            attacker.Attack(defender, damage);

            // Assert
            defender.Health.Should().Be(defenderHealth);
        }

        [Fact]
        public void Debe_un_personaje_morir_si_recibe_un_ataque_mayor_a_su_vida_actual()
        {
            // Arrange
            var attacker = new Character();
            var defender = new Character();

            // Act
            attacker.Attack(defender, 1_001);

            // Assert
            defender.Health.Should().BeLessThanOrEqualTo(0);
        }

        [Fact]
        public void Debe_cambiar_el_estado_de_un_personaje_a_muerto_cuando_su_vida_es_igual_o_menor_a_0()
        {
            // Arrange
            var attacker = new Character();
            var defender = new Character();

            attacker.Attack(defender, 1_000);

            // Act
            var defenderStillAlive = defender.IsAlive();

            // Assert
            defenderStillAlive.Should().BeFalse();
        }

        [Fact]
        public void Debe_evitar_que_un_personaje_se_haga_daño_a_si_mismo()
        {
            // Arrange
            var character = new Character();

            // Act
            var ataque = () => character.Attack(character, 100);

            // Assert
            ataque.Should().Throw<InvalidOperationException>()
                .WithMessage("No puedes hacerte daño a ti mismo.");
        }

        [Fact]
        public void Debe_poder_curarse_a_si_mismo_si_esta_vivo()
        {
            // Arrange
            var character = new Character();

            // Act
            character.Cure(100);

            // Assert
            character.IsAlive().Should().BeTrue();
            character.Health.Should().Be(1100);
        }

        [Fact]
        public void Debe_arrojar_una_excepcion_si_un_personaje_muerto_intenta_curarse()
        {
            // Arrange
            var character = new Character();
            character.TakeDamage(1_000);

            // Act
            var cure = () => character.Cure(1_000);

            // Assert
            cure.Should().Throw<InvalidOperationException>();

        }

        [Theory]
        [InlineData(100, 1_100), InlineData(200, 1_200), InlineData(300, 1_300)]
        public void Debe_aumentar_su_vida_en_la_cantidad_curada_al_curarse_a_si_mismo(int curedHealth, int finalHealth)
        {
            // Arrange
            var character = new Character();

            // Act
            character.Cure(curedHealth);

            // Assert
            character.Health.Should().Be(finalHealth);
        }

        [Fact]
        public void Debe_permitir_crear_un_personaje_y_su_nivel_inicial_debe_ser_1()
        {
            // Arrange
            var character = new Character();

            // Act
            var level = character.Level;

            // Assert
            level.Should().Be(1);
        }

        [Fact]
        public void Debe_arrojar_una_excepcion_si_un_personaje_muerto_intenta_subir_de_nivel()
        {
            // Arrange
            var character  = new Character();
            character.TakeDamage(1000);


            // Act
            var levelUp = () => character.LevelUp();

            // Assert
            character.Level.Should().Be(1);
            levelUp.Should().Throw<InvalidOperationException>()
                .WithMessage("No puedes subir de nivel si estás muerto.");
        }
    }
}
