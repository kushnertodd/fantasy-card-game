using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Cards
    {
        private static Random rng = new Random();

        public List<Card> cards = new List<Card>();

        /**
         * https://www.delftstack.com/howto/csharp/shuffle-a-list-in-csharp/
         */
        public void Shuffle(int count = 1)
        {
            for (int i = 0; i < count; i++)
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
        }
        public void Add(Card card)
        {
            cards.Add(card);
        }

        public string ToString(string prefix = "", string separator = " ", string suffix = "")
        {
            return ListUtilities<Card>.ToString(cards, prefix, separator, suffix);
        }
        public virtual void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + ToString());
        }
    }
}
