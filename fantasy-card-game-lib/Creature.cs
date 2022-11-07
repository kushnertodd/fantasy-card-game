using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Creature : Card
    {
        public bool isCommander = false;
        public bool isPlanesWalker = false;
        public int power = 0;
        public int strength = 0;
        public Creature(string name, bool isCommander = false, bool isPlanesWalter = false, int power = 0, int strength = 0)
        {
            this.name = name;
            this.isCommander = isCommander;
            this.isPlanesWalker = isPlanesWalter;
            this.power = power;
            this.strength = strength;
        }

        public string CreatureType()
        {
            if (this.isCommander) return "Commander";
            if (this.isPlanesWalker) return "PlanesWalker";
            return "";
        }

        public override string ToString()
        {
            return base.ToString() +
                (isCommander || isPlanesWalker ? "/" + CreatureType() : "") +
                "(" + strength + "/" + power + ")";
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
