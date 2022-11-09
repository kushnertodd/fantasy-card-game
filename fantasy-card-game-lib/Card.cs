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
        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
        private bool isPermanent = false;
        public bool IsPermanent
        {
            get => isPermanent;
            set => isPermanent = value;
        }
        private bool isSpell = false;
        public bool IsSpell
        {
            get => isSpell;
            set => isSpell = value;
        }
        private bool isTappable = false;
        public bool IsTappable
        {
            get => isTappable;
            set => isTappable = value;
        }

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
