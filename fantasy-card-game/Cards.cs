using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game
{
    internal class Cards
    {
        private static Random rng = new Random();

        public List<Card> cards;

        /**
         * https://www.delftstack.com/howto/csharp/shuffle-a-list-in-csharp/
         */
        public void Shuffle()
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
        public void Add(Card card)
        {
            cards.Add(card);
        }

        public string ToString()
        {
            string description = "";
            if (cards.Count > 0)
            {
                foreach (Card card in cards)
                {
                    description += " " + card.ToString();
                }
            }
            return description;
        }
    }
}
