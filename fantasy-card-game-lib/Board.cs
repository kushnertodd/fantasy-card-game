using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    internal class Board
    {
        List<Creature> creatures;
        List<Artifact> artifacts;
        List<Equipment> equipments;
        List<Enchantment> enchantments;
        List<Land> lands;
        public string name;

        public Board(string name)
        {
            this.name = name;
            creatures = new List<Creature>();
            artifacts = new List<Artifact>();
            equipments = new List<Equipment>();
            enchantments = new List<Enchantment>();
            lands = new List<Land>();
        }

        public void Add(Creature creature)
        {
            creatures.Add(creature);
        }
        public void Add(Artifact artifact)
        {
            artifacts.Add(artifact);
        }
        public void Add(Equipment equipment)
        {
            equipments.Add(equipment);
        }
        public void Add(Enchantment enchantment)
        {
            enchantments.Add(enchantment);
        }
        public void Add(Land land)
        {
            lands.Add(land);
        }

        public string ToString()
        {
            string description = "board " + name;
            if (creatures.Count > 0)
            {
                description += " creatures (";
                foreach (Creature creature in creatures)
                {
                    description += " " + creature.name;
                }
                description += " )";
            }
            if (artifacts.Count > 0)
            {
                description += " artifacts (";
                foreach (Artifact artifact in artifacts)
                {
                    description += " " + artifact.name;
                }
                description += " )";
            }
            if (equipments.Count > 0)
            {
                description += " equipments (";
                foreach (Equipment equipment in equipments)
                {
                    description += " " + equipment.name;
                }
                description += ")";
            }
            if (enchantments.Count > 0)
            {
                description += " enchantments (";
                foreach (Enchantment enchantment in enchantments)
                {
                    description += " " + enchantment.name;
                }
                description += " )";
            }
            if (lands.Count > 0)
            {
                description += " with creatures (";
                foreach (Land land in lands)
                {
                    description += " " + land.name;
                }
                description += " )";
            }
            return description;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
