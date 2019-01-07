using InfernoInfinity.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        public Sword(WeaponRarity rarity, string name)
            : base(rarity, name, 4, 6, 3)
        {
        }
    }
}
