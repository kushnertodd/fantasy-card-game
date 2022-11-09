using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fantasy_card_game_lib
{
    public class Boards
    {
        private List<Board> boards = new List<Board>();
        public Boards() { }
        public void Add(Board board)
        {
            boards.Add(board);
        }
        public Board Select(string name)
        {
            if (boards == null) return null;
            else
                return boards.Find(board => board.Name == name);
        }
        public string ToString(string prefix = "", string separator = " ", string suffix = "")
        {
            return ListUtilities<Board>.ToString(boards, prefix, separator, suffix);
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
