namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            List<IEnemy> fasterArmy = new List<IEnemy>();

            for (int i = 0; i < this.Size; i++)
            {
                if (this.enemies[i].AttackSpeed > speed)
                {
                    fasterArmy.Add(this.enemies[i]);
                }
            }

            return fasterArmy;
        }

        public IEnemy GetFastest()
        {
            this.EnsureNotEmpty();

            return this.enemies.GetFirst();
        }

        public IEnemy[] GetOrderedByHealth()
        {
            return this.enemies.OrderByDescending(x => x.Health).ToArray();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            List<IEnemy> slowerArmy = new List<IEnemy>();

            for (int i = 0; i < this.Size; i++)
            {
                if (this.enemies[i].AttackSpeed < speed)
                {
                    slowerArmy.Add(this.enemies[i]);
                }
            }

            return slowerArmy;
        }

        public IEnemy GetSlowest()
        {
            this.EnsureNotEmpty();

            return this.enemies.GetLast();
        }

        public void ShootFastest()
        {
            this.EnsureNotEmpty();

            this.enemies.RemoveFirst();
        }

        public void ShootSlowest()
        {
            this.EnsureNotEmpty();

            this.enemies.RemoveLast();
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
