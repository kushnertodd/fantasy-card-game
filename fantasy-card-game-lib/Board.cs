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
        List<Creature> creatures;
        List<Artifact> artifacts;
        List<Equipment> equipments;
        List<Enchantment> enchantments;
        List<Land> lands;
        public Deck deck;
        public Player player;
        public string Name { get; set; }
        public Board board;

        public Board(string name, Board board, Deck deck)
        {
            Name = name;
            creatures = new List<Creature>();
            artifacts = new List<Artifact>();
            equipments = new List<Equipment>();
            enchantments = new List<Enchantment>();
            lands = new List<Land>();
            this.board = board;
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

        public string toString()
        {
            string description = Name;
            if (creatures.Count > 0)
            {
                description += " creatures: (";
                foreach (Creature creature in creatures)
                {
                    description += " " + creature.toString();
                }
                description += " )";
            }
            if (artifacts.Count > 0)
            {
                description += " artifacts: (";
                foreach (Artifact artifact in artifacts)
                {
                    description += " " + artifact.toString();
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
        public void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + toString());
        }
    }
}
