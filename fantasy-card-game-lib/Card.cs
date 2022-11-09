using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fantasy_card_game_lib
{
    public class Card
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public bool IsPermanent { get; set; }
        public bool IsSpell { get; set; }
        public bool CanTap { get; set; }
        public Card(string name, int cost = 0,  bool isPermanent = false, bool isSpell = false, bool canTap = false)
        {
            Name = name;
            Cost = cost;
            IsPermanent = isPermanent;
            IsSpell = isSpell;
            CanTap = canTap;
        }
        public override string ToString()
        {
            return this.GetType().Name + ":" + Name;
        }
        public virtual void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
