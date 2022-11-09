using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Player
    {
        public string Name { get; set; }
        public Player(string name)
        {
            Name = name;
        }
        public Creature SelectCommander(Cards cards, string name)
        {
            foreach (Card card in cards.cards)
            {
                if (card.GetType() == typeof(Creature) && card.Name == name)
                {
                    return (Creature)card;
                }
            }
            return null;
        }
        public override string ToString()
        {
            return Name;
        }
        public void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + ToString());
        }
    }
}
