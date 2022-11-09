using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Land : Card
    {
        public Mana mana;
        public Land(string name, Mana mana) :
                        base(name, isPermanent: true, canTap: true)
        {
            Name = name;
            this.mana = mana;
        }

        void Add(Mana.Color color)
        {
            mana.Add(color);
        }
        public override string ToString()
        {
            return base.ToString() + mana.ToString();
        }
    }
}
