﻿namespace RPGCombat.Domain.Tests
{
    public class Character
    {
        public double Health { get; private set; }
        public int Level { get; private set; }
        public int MaxHealth { get; internal set; }

        public Character()
        {
            Health = 1_000;
            Level = 1;
            MaxHealth = 1_000;
        }

        public void Attack(Character defender, int damage)
        {
            if (this == defender)
            {
                throw new InvalidOperationException("No puedes hacerte daño a ti mismo.");
            }

            var finalDamage = CalculateDamagePerLevels(defender, damage);

            defender.TakeDamage(finalDamage);
        }

        private double CalculateDamagePerLevels(Character defender, int damage)
        {
            int levelDifference = defender.Level - Level;
            double finalDamage = 0;

            if (levelDifference >= 5)
            {
                finalDamage = damage * 0.5;
            }
            else if (levelDifference <= -5)
            {
                finalDamage = 750;
            }
            else
            {
                finalDamage = damage;
            }

            return finalDamage;
        }

        public void TakeDamage(double damage)
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
                if (Health > MaxHealth)
                {
                    Health = MaxHealth;
                }
            }
            else
            {
                throw new InvalidOperationException("No puedes curarte si estás muerto.");
            }
        }

        public void LevelUp(int level = 1)
        {
            if (!IsAlive())
            {
                throw new InvalidOperationException("No puedes subir de nivel si estás muerto.");
            }

            Level = level;
            MaxHealth = 1_500;
            Health = MaxHealth;
        }
    }
}
