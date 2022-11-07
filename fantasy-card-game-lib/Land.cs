using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Land : Card
    {

        public Land(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
