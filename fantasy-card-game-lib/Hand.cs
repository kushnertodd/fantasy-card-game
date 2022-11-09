using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Hand : Cards
    {
        public Hand()
        {
            cards = new List<Card>();
        }

        public override string ToString()
        {
            string description = base.ToString();
            return description;
        }
        public override void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + ToString());
        }

    }
}
