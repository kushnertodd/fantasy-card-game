using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game
{
    internal class Equipment : Card
    {

        public Equipment(string name)
        {
            this.name = name;
        }

        public string ToString()
        {
            return "this is equipment " + name;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
