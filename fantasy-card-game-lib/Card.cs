using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Card
    {
        public string Name { get; set; }

        public virtual string toString()
        {
            return this.GetType().Name + ":" + Name;
        }
        public virtual void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + toString());
        }
    }
}
