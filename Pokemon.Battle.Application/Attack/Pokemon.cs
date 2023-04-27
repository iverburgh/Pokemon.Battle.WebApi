using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Battle.Application.Attack
{
    public class Pokemon
    {
        public int PokedexNumber { get; set; }

        public string Name { get; set; } = default!;

        public int Level { get; set; }

        public BattleType PrimaryType { get; set; }

        public BattleType? SecondaryType { get; set; }

        public int AttackPower { get; set; }
        
        public int SpecialDefensivePower { get; set; }

        public int SpecialAttackPower { get; set; }

        public int DefensivePower { get; set; }

        public int HitPoint { get; set; }
    }
}