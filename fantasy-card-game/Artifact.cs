using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game
{
    internal class Artifact : Card
    {

        public Artifact(string name)
        {
            this.name = name;
        }

        public string ToString()
        {
            return "this is artifact " + name;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
