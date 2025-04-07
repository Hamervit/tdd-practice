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
            character.Health.Should().Be(1000);
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
        [InlineData(100, 1_000), InlineData(200, 1_000), InlineData(300, 1_000)]
        public void Debe_aumentar_su_vida_en_la_cantidad_curada_al_curarse_a_si_mismo_teniendo_en_cuenta_el_limite_de_vida_por_nivel(int curedHealth, int finalHealth)
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
            var character = new Character();
            character.TakeDamage(1000);


            // Act
            var levelUp = () => character.LevelUp();

            // Assert
            character.Level.Should().Be(1);
            levelUp.Should().Throw<InvalidOperationException>()
                .WithMessage("No puedes subir de nivel si estás muerto.");
        }

        [Fact]
        public void Debe_evitar_que_un_personaje_se_cure_mas_de_lo_que_su_nivel_actual_le_permite()
        {
            // Arrange
            var character = new Character();

            // Act
            character.Cure(1_000);

            // Assert
            character.Level.Should().BeLessThan(6);
            character.Health.Should().Be(1_000);
        }

        [Fact]
        public void Debe_la_vida_actual_del_personaje_ser_500_cuando_su_vida_maxima_es_1000_recibe_un_ataque_de_800_y_se_cura_300()
        {
            // Arrange
            var character = new Character();
            character.TakeDamage(800);
            character.Cure(300);


            // Act
            var health = character.Health;

            // Assert
            health.Should().Be(500);
        }

        [Fact]
        public void Debe_un_personaje_poder_subir_de_nivel_y_al_alcanzar_el_nivel_6_su_vida_máxima_debe_aumentar_a_1500()
        {
            // Arrange
            var character = new Character();

            // Act
            character.LevelUp(6);

            // Assert
            character.Level.Should().Be(6);
            character.MaxHealth.Should().Be(1_500);
        }

        [Fact]
        public void Debe_un_personaje_tener_1200_de_vida_cuando_recibe_un_ataque_de_700_y_se_cura_400_y_es_nivel_6()
        {
            // Arrange
            var character = new Character();
            character.LevelUp(6);
            character.TakeDamage(700);
            character.Cure(400);

            // Assert
            character.Health.Should().Be(1_200);
        }

        [Theory]
        [InlineData(6, 700, 1150), InlineData(6, 800, 1100), InlineData(6, 1000, 1000)]
        public void Debe_disminuir_el_daño_de_ataque_de_un_personaje_en_un_50_porciento_si_el_personaje_al_que_ataca_lo_supera_por_5_niveles_o_más(int defenderLevel, int attackerDamage, int defenderHealth)
        {
            // Arrange
            var attacker = new Character();
            var defender = new Character();

            defender.LevelUp(defenderLevel);

            // Act
            attacker.Attack(defender, attackerDamage);

            // Assert
            defender.Health.Should().Be(defenderHealth);
        }

        [Theory]
        [InlineData(500, 250), InlineData(150, 775), InlineData(300, 550), InlineData(50, 925)]
        public void Debe_aumentar_el_daño_de_ataque_de_un_personaje_en_un_50_porciento_si_el_personaje_al_que_ataca_es_inferior_por_5_niveles_o_más(double attackerDamage, double expectedDefenderHealth)
        {
            // Arrange
            var attacker = new Character();
            var defender = new Character();

            attacker.LevelUp(6);

            // Act
            attacker.Attack(defender, attackerDamage);

            // Assert
            defender.Health.Should().Be(expectedDefenderHealth);
        }
    }
}
