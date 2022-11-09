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

        public void SelectBoard(Table table, string name)
        {
            board = table.SelectBoard(name);
        }
        public Creature SelectCommander(Cards cards, string name)
        {
            Creature commander = null;
            foreach (Card card in cards.cards)
            {
                if (card.GetType() == typeof(Creature) && card.Name == name)
                {
                    commander = (Creature) card;
                    break;
                }
            }
            return commander;
        }
        public string toString()
        {
            return Name;
        }
        public void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + toString());
            board.Describe();
            deck.Describe();
        }
    }
}
