using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    internal class Equipment : Card
    {

        public Equipment(string name)
        {
            this.name = name;
        }

        public string ToString()
        {
            return "Equipment/" + name;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
