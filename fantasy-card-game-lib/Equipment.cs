using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Equipment : Card
    {

        public Equipment(string name) :
                        base(name, isPermanent: true, isSpell: false, canTap: false)
        {
            Name = name;
        }

    }
}
