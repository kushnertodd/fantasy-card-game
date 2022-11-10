using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fantasy_card_game_lib
{
    public class ManaPool
    {
        private List<Mana> manaPool = new List<Mana>();
        public ManaPool() { }
        public void Add(ManaPool manaPool)
        {
            manaPool.Add(manaPool);
        }
        public string ToString(string prefix = "", string separator = " ", string suffix = "")
        {
            return ListUtilities<Mana>.ToString(manaPool, prefix, separator, suffix);
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
