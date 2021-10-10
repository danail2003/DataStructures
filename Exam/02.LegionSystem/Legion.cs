namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using _02.LegionSystem.Interfaces;
    using Wintellect.PowerCollections;

    public class Legion : IArmy
    {
        private readonly OrderedSet<IEnemy> enemies;

        public Legion()
        {
            this.enemies = new OrderedSet<IEnemy>();
        }

        public int Size => this.enemies.Count;

        public bool Contains(IEnemy enemy)
        {
            int searchedWeapon = this.enemies.IndexOf(enemy);

            if (searchedWeapon != -1)
            {
                return true;
            }

            return false;
        }

        public void Create(IEnemy enemy)
        {
            this.enemies.Add(enemy);
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            IEnemy enemy = null;

            for (int i = 0; i < this.Size; i++)
            {
                if (this.enemies[i].AttackSpeed == speed)
                {
                    enemy = this.enemies[i];
                }
            }

            return enemy;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            throw new NotImplementedException();
        }

        public IEnemy GetFastest()
        {
            this.EnsureNotEmpty();

            IEnemy enemy = null;

            int maxAttackSpeed = int.MinValue;

            for (int i = 0; i < this.Size; i++)
            {
                if (this.enemies[i].AttackSpeed > maxAttackSpeed)
                {
                    maxAttackSpeed = this.enemies[i].AttackSpeed;
                    enemy = this.enemies[i];
                }
            }

            return enemy;
        }

        public IEnemy[] GetOrderedByHealth()
        {
            throw new NotImplementedException();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            throw new NotImplementedException();
        }

        public IEnemy GetSlowest()
        {
            throw new NotImplementedException();
        }

        public void ShootFastest()
        {
            throw new NotImplementedException();
        }

        public void ShootSlowest()
        {
            throw new NotImplementedException();
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }
    }
}
