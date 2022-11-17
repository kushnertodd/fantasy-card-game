using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class CardPool : Cards
    {
        public CardPool()
        {
            cards = new List<Card>();
        }
        public Creature SelectCommander(Cards cards, string name)
        {
            foreach (Card card in cards.cards)
            {
                if (card.GetType() == typeof(Creature) && card.Name == name)
                {
                    Creature creature = (Creature)card;
                    if (creature.IsCommander)
                        return creature;
                    else
                        return null!;
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
