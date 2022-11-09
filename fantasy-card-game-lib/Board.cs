using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Board
    {
        List<Creature> creatures = new List<Creature>();
        List<Artifact> artifacts = new List<Artifact>();
        List<Equipment> equipments = new List<Equipment>();
        List<Enchantment> enchantments = new List<Enchantment>();
        List<Land> lands = new List<Land>();
        public Player player;
        public Deck deck;
        public string Name { get; set; }

        public Board(string name, Player player, Deck deck)
        {
            Name = name;
            this.player = player;
            this.deck = deck;
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

        public override string ToString()
        {
            string description = Name;
            if (creatures.Count > 0)
            {
                description += " creatures: (";
                foreach (Creature creature in creatures)
                {
                    description += " " + creature.ToString();
                }
                description += " )";
            }
            if (artifacts.Count > 0)
            {
                description += " artifacts: (";
                foreach (Artifact artifact in artifacts)
                {
                    description += " " + artifact.ToString();
                }
                description += " )";
            }
            if (equipments.Count > 0)
            {
                description += " equipments: (";
                foreach (Equipment equipment in equipments)
                {
                    description += " " + equipment.Name;
                }
                description += ")";
            }
            if (enchantments.Count > 0)
            {
                description += " enchantments: (";
                foreach (Enchantment enchantment in enchantments)
                {
                    description += " " + enchantment.Name;
                }
                description += " )";
            }
            if (lands.Count > 0)
            {
                description += " lands: (";
                foreach (Land land in lands)
                {
                    description += " " + land.Name;
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
