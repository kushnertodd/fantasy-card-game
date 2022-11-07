﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Creature : Card
    {

        public Creature(string name)
        {
            this.name = name;
        }

        public string ToString()
        {
            return "Creature/" + name;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
