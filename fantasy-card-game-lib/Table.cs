using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fantasy_card_game_lib
{
    public class Table
    {
        public string Name { get; set; }
        public List<Board> boards = new List<Board>();

        public Table(string name)
        {
            Name = name;
        }

        public void Add(Board board)
        {
            boards.Add(board);
        }

        public Board SelectBoard(string name)
        {
            Board result = boards.Find(board => board.Name == name);
            return result;
        }

        public string toString()
        {
            string description = Name + " boards:";
            foreach (Board board in boards)
            {
                description += " " + board.toString();
            }
            return description;
        }
        public void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + toString());
        }
    }
}
