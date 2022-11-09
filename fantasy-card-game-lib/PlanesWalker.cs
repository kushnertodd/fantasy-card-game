using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Planeswalker : Card
    {
        public int Power { get; set; }
        public int Toughness { get; set; }

        public Planeswalker(string name,
            int power = 0,
            int toughness = 0
            ) : base(name, canBeAttacked: true, isPermanent: true, isSpell: true)
        {
            Name = name;
            Power = power;
            Toughness = toughness;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
