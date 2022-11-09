using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Creature : Card
    {
        public bool IsCommander { get; set; }
        public bool IsPlanesWalker { get; set; }
        public bool CanSwing { get; set; }
        public int Power { get; set; }
        public int Toughness { get; set; }
        public Creature(string name, bool isCommander = false, bool isPlanesWalter = false, int power = 0, int toughness = 0) :
                        base(name, isPermanent: true, isSpell: false, canTap: false)
        {
            Name = name;
            IsCommander = isCommander;
            IsPlanesWalker = isPlanesWalter;
            Power = power;
            Toughness = toughness;
        }

        public string CreatureType()
        {
            if (IsCommander) return "Commander";
            if (IsPlanesWalker) return "PlanesWalker";
            return "";
        }

        public override string ToString()
        {
            return base.ToString() +
                (IsCommander || IsPlanesWalker ? "/" + CreatureType() : "") +
                "(" + Power + "/" + Toughness + ")";
        }
    }
}
