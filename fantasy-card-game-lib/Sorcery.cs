﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Sorcery : Card
    {

        public Sorcery(string name) :
                        base(name, isPermanent: false, isSpell: true, canTap: false)
        {

        }
    }
}
