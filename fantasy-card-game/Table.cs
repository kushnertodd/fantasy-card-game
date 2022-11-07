using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fantasy_card_game
{
    internal class Table
    {
        public string name;
        List<Board> boards = new List<Board>();
        public void Add(Board board)
        {
            boards.Add(board);
        }

        public string ToString()
        {
            string description = "this is table " + name + " with boards";
            foreach (Board board in boards)
            {
                description += " " + board;
            }
            return description;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
