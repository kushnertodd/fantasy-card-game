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
        public Planeswalker SelectCommander(Cards cards, string name)
        {
            foreach (Card card in cards.cards)
            {
                if (card.GetType() == typeof(Planeswalker) && card.Name == name)
                {
                    return (Planeswalker)card;
                }
            }
            return null!;
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
