﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Creature : Card
    {
        public bool IsCommander { get; set; }
        public int Power { get; set; }
        public int Toughness { get; set; }
        public Creature(string name,
            bool isCommander = false,
            int power = 0,
            int toughness = 0
            ) : base(name, canAttack: true, isPermanent: true, isSpell: true)
        {
            Name = name;
            IsCommander = isCommander;
            Power = power;
            Toughness = toughness;
        }

        public override string ToString()
        {
            return base.ToString() +
                (IsCommander ? ":Commander" : "") +
                "(" + Power + "/" + Toughness + ")";
        }
    }
}
