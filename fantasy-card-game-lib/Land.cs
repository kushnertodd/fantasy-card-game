﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    internal class Land : Card
    {

        public Land(string name)
        {
            this.name = name;
        }

        public string ToString()
        {
            return "Land/" + name;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}