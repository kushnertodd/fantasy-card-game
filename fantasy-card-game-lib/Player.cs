using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Player
    {
        public string name;
        public Board board;
        public Deck deck;

        public Player(string name, Board board, Deck deck)
        {
            this.name = name;
            this.board = board;
            this.deck = deck;
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
                if (card.GetType() == typeof(Creature) && card.name == name)
                {
                    commander = (Creature) card;
                    break;
                }
            }
            return commander;
        }
        public string ToString()
        {
            return name;
        }
        public void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + ToString());
            board.Describe();
            deck.Describe();
        }
    }
}
