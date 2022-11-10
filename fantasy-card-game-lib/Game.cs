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
    public class Game
    {
        public Players players = new Players();
        public Game() { }
        public void Add(Player player)
        {
            players.Add(player);
        }
        public Player SelectPlayer(string name, Errors errors)
        {
            return players.Select(name, errors);
        }
        public void Start()
        {

        }
        public string ToString(string prefix = "", string separator = " ", string suffix = "")
        {
            return players.ToString(prefix, separator, suffix);
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
