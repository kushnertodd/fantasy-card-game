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
        public bool CanAttack { get; set; }
        public bool CanBeAttacked { get; set; }
        public bool CanTap { get; set; }
        public int Cost { get; set; }
        public bool IsPermanent { get; set; }
        public bool IsSpell { get; set; }
        public Card(string name,
            bool canAttack = false,
            bool canBeAttacked = false,
            bool canTap = false,
            int cost = 0,
            bool isPermanent = false,
            bool isSpell = false
            )
        {
            Name = name;
            CanBeAttacked = canBeAttacked;
            CanAttack = canAttack;
            CanTap = canTap;
            Cost = cost;
            IsPermanent = isPermanent;
            IsSpell = isSpell;
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
