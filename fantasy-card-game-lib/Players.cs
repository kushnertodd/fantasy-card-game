using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fantasy_card_game_lib
{
    public class Players
    {
        private List<Player> players = new List<Player>();
        public Players() { }
        public void Add(Player player)
        {
            players.Add(player);
        }
        public Player Select(string name)
        {
            return players.Find(player => player.Name == name)!;
        }
        public string ToString(string prefix = "", string separator = " ", string suffix = "")
        {
            return ListUtilities<Player>.ToString(players, prefix, separator, suffix);
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
