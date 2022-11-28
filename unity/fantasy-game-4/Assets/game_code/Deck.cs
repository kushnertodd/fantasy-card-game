using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fantasy_card_game_lib
{
    public class Deck : Cards
    {

        public Deck()
        {
            cards = new List<Card>();
        }

        public Hand DrawHand(int size)
        {
            Hand hand = new Hand();
            for (int i = 0; i < size; i++)
            {
                hand.Add(cards[0]);
                cards.RemoveAt(0);
            }
            return hand;
        }
        public Creature SelectCommander(Errors errors)
        {
            foreach (Card card in cards)
            {
                if (card.GetType() == typeof(Creature))
                {
                    Creature creature = (Creature)card;
                    if (creature.IsCommander)
                    {
                        return creature;
                    }
                }
            }
            return null!;
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
