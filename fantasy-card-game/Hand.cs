using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game
{
    internal class Hand
    {
        List<Card> cards;
        public Hand()
        {
            cards = new List<Card>();
        }

            public void Add(Card card)
        {
            cards.Add(card);
        }
    }
}
