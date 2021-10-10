﻿namespace _02.LegionSystem.Models
{
    using _02.LegionSystem.Interfaces;

    public class Enemy : IEnemy
    {
        public Enemy(int attackSpeed, int health)
        {
            this.AttackSpeed = attackSpeed;
            this.Health = health;
        }

        public int AttackSpeed { get; set; }

        public int Health { get; set; }

        public int CompareTo(object obj)
        {
            IEnemy enemy = (IEnemy)obj;

            return enemy.AttackSpeed - this.AttackSpeed;
        }
    }
}
