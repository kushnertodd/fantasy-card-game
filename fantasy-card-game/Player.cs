using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game
{
    internal class Player
    {
        public string name;
        public Board board;

        public Player(string name, Board board)
        {
            this.name = name;
            this.board = board;
        }

        public string ToString()
        {
            return "player " + name + " " + board.ToString();
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
