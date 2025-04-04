namespace RPGCombat.Domain.Tests
{
    public class Character
    {
        public int Health { get; private set; }
        public int Level { get; private set; }

        public Character()
        {
            Health = 1_000;
            Level = 1;
        }

        public void Attack(Character defender, int damage)
        {
            if (this == defender)
            {
                throw new InvalidOperationException("No puedes hacerte daño a ti mismo.");
            }

            defender.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void Cure(int health)
        {
            if (IsAlive())
            {
                Health += health;
            }
            else
            {
                throw new InvalidOperationException("No puedes curarte si estás muerto.");
            }
        }

        public void LevelUp()
        {
            
        }
    }
}
