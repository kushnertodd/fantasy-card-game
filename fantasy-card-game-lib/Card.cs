using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    internal class Card
    {
        public string name;
        public int power = 0;
        public int strength = 0;

        public string ToString()
        {
            return this.GetType().Name + ":" + name + "(" + strength + "/" + power + ")";
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
