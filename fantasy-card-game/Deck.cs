using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fantasy_card_game
{
    internal class Deck : Cards
    {

        public Deck()
        {
            this.cards = new List<Card>();
        }

        public Hand Deal(int size)
        {
            Hand hand = new Hand();
            for (int i = 0; i < size; i++)
            {
                hand.Add(cards[0]);
                cards.RemoveAt(0);
            }
            return hand;
        }
        public string ToString()
        {
            string description = "deck " + base.ToString();
            return description;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }

    }
}
