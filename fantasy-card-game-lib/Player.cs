using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Player
    {
        public string Name { get; set; }
        public int LifePoints { get; set; }
        public int CommanderDamage { get; set; }
        public Battlefield battlefield;

        public Player(string name, Battlefield battlefield)
        {
            Name = name;
            LifePoints = 40;
            CommanderDamage = 0;
            this.battlefield = battlefield;
        }
        public override string ToString()
        {
            return Name;
        }
        public void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + ToString());
        }
    }
}
