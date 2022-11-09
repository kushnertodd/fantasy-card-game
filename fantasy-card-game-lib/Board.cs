using Microsoft.VisualBasic;
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
        List<Artifact> artifacts = new List<Artifact>();
        List<Creature> creatures = new List<Creature>();
        List<Equipment> equipments = new List<Equipment>();
        List<Enchantment> enchantments = new List<Enchantment>();
        List<Instant> instants = new List<Instant>();
        List<Land> lands = new List<Land>();
        List<Planeswalker> planeswalkers = new List<Planeswalker>();
        List<Sorcery> sorceries = new List<Sorcery>();
        public Player player;
        public Deck deck;
        public string Name { get; set; }

        public Board(string name, Player player, Deck deck)
        {
            Name = name;
            this.player = player;
            this.deck = deck;
        }

        public void Add(Artifact artifact)
        {
            artifacts.Add(artifact);
        }
        public void Add(Creature creature)
        {
            creatures.Add(creature);
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
        public void Add(Instant instant)
        {
            instants.Add(instant);
        }
        public void Add(Planeswalker planeswalker)
        {
            planeswalkers.Add(planeswalker);
        }
        public void Add(Sorcery sorcery)
        {
            sorceries.Add(sorcery);
        }

        public override string ToString()
        {
            string description = Name;
            if (artifacts.Count > 0)
            {
                description += " artifacts: (" +
                    ListUtilities<Artifact>.ToString(artifacts);
                description += " )";
            }
            if (creatures.Count > 0)
            {
                description += " creatures: (" +
                    ListUtilities<Creature>.ToString(creatures);
                description += " )";
            }
            if (enchantments.Count > 0)
            {
                description += " enchantments: (";
                ListUtilities<Enchantment>.ToString(enchantments);
                description += " )";
            }
            if (equipments.Count > 0)
            {
                description += " equipments: (";
                ListUtilities<Equipment>.ToString(equipments);
                description += ")";
            }
            if (instants.Count > 0)
            {
                description += " instants: (";
                ListUtilities<Instant>.ToString(instants);
                description += ")";
            }
            if (lands.Count > 0)
            {
                description += " lands: (";
                ListUtilities<Land>.ToString(lands);
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
