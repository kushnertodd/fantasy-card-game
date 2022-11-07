using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game
{
    internal class Hand : Cards
    {
        public Hand()
        {
            cards = new List<Card>();
        }

        public string ToString()
        {
            string description = "hand " + base.ToString();
            return description;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
