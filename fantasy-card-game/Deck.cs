using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fantasy_card_game
{
    internal class Deck
    {
        List<Card> cards;
        public Deck()
        {
            cards = new List<Card>();
        }

        public void Add(Card card)
        {
            cards.Add(card);
        }
        public string ToString()
        {
            string description = "deck ";
            if (cards.Count > 0)
            {
                foreach (Card card in cards)
                {
                    description += " " + card.name;
                }
                description += " )";
            }
            return description;
        }

    }
}
