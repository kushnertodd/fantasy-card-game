using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game
{
    internal class Enchantment
    {
        public string name;

        public Enchantment(string name)
        {
            this.name = name;
        }

        public string ToString()
        {
            return "this is enchantment " + name;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
