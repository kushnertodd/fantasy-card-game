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
        public string ToString()
        {
            return "player " + name;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
            board.Describe();
            deck.Describe();
        }
    }
}
