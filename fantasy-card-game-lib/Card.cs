using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Card
    {
        public string name;

        public virtual string ToString()
        {
            return this.GetType().Name + ":" + name;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
