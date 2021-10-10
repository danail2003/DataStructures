namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private List<IWeapon> weapons;

        public Inventory()
        {
            this.weapons = new List<IWeapon>();
        }

        public int Capacity => this.weapons.Count;

        public void Add(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public void Clear()
        {
            this.weapons.Clear();
        }

        public bool Contains(IWeapon weapon)
        {
            return this.GetById(weapon.Id) != null;
        }

        public void EmptyArsenal(Category category)
        {
            for (int i = 0; i < this.Capacity; i++)
            {
                if (this.weapons[i].Category == category)
                {
                    this.weapons[i].Ammunition = 0;
                }
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            IWeapon searchedWeapon = this.GetById(weapon.Id);

            if (searchedWeapon == null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            if (ammunition > searchedWeapon.Ammunition)
            {
                return false;
            }

            searchedWeapon.Ammunition -= ammunition;

            return true;
        }

        public IWeapon GetById(int id)
        {
            IWeapon weapon = this.weapons.Find(x => x.Id == id);

            return weapon;
        }

        public IEnumerator GetEnumerator()
        {
            return this.weapons.GetEnumerator();
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            IWeapon searchedWeapon = this.GetById(weapon.Id);

            if (searchedWeapon == null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            if (ammunition + searchedWeapon.Ammunition > searchedWeapon.MaxCapacity)
            {
                searchedWeapon.Ammunition += searchedWeapon.MaxCapacity - searchedWeapon.Ammunition;
            }
            else
            {
                searchedWeapon.Ammunition += ammunition;
            }

            return searchedWeapon.Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            IWeapon searchedWeapon = this.weapons.Find(x => x.Id == id);

            if (searchedWeapon == null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            this.weapons.Remove(searchedWeapon);

            return searchedWeapon;
        }

        public int RemoveHeavy()
        {
            int count = 0;

            for (int i = 0; i < this.Capacity; i++)
            {
                if ((int)this.weapons[i].Category == 2)
                {
                    count++;
                    this.weapons.Remove(this.weapons[i]);
                    i--;
                }
            }

            return count;
        }

        public List<IWeapon> RetrieveAll()
        {
            return new List<IWeapon>(this.weapons);
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            List<IWeapon> weapons = new List<IWeapon>();

            for (int i = 0; i < this.Capacity; i++)
            {
                if ((int)this.weapons[i].Category >= (int)lower && (int)this.weapons[i].Category <= (int)upper)
                {
                    weapons.Add(this.weapons[i]);
                } 
            }

            return weapons;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            int firstWeaponIndex = this.weapons.IndexOf(firstWeapon);
            int secondWeaponIndex = this.weapons.IndexOf(secondWeapon);

            if (firstWeaponIndex == -1 || secondWeaponIndex == -1)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            if (firstWeapon.Category == secondWeapon.Category)
            {
                IWeapon temp = this.weapons[firstWeaponIndex];
                this.weapons[firstWeaponIndex] = this.weapons[secondWeaponIndex];
                this.weapons[secondWeaponIndex] = temp;
            }
        }
    }
}
