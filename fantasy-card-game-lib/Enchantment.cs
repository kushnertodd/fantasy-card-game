using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Enchantment : Card
    {
        public Enchantment(string name)
        {
            Name = name;
        }
        public override string toString()
        {
            return base.toString();
        }
        public override void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + toString());
        }

    }
}
