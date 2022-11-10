using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Battlefield
    {
        public List<Artifact> artifacts = new List<Artifact>();
        public List<Creature> creatures = new List<Creature>();
        public List<Equipment> equipments = new List<Equipment>();
        public List<Enchantment> enchantments = new List<Enchantment>();
        public List<Instant> instants = new List<Instant>();
        public List<Land> lands = new List<Land>();
        public List<Planeswalker> planeswalkers = new List<Planeswalker>();
        public List<Sorcery> sorceries = new List<Sorcery>();
        public Dictionary<Mana.Color, int> manaCounts = new Dictionary<Mana.Color, int>();
        public Deck deck;
        public Exile exile;
        public Graveyard graveyard;

        public Battlefield(Deck deck)
        {
            this.deck = deck;
            exile = new Exile();
            graveyard = new Graveyard();
            foreach (Mana.Color color in Enum.GetValues(typeof(Mana.Color)))
            {
                manaCounts.Add(color, 0);
            }
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
        public int GetManaCount(Mana.Color color)
        {
            return manaCounts[color];
        }
        public void Play(Card card, Errors errors)
        {
            if (card.GetType() == typeof(Artifact))
            {
            }
            else if (card.GetType() == typeof(Creature))
            {
                Creature creature = (Creature)card;
                int creatureCost = creature.Cost;
                Mana.Color creatureCostColor = creature.CostColor;
                int manaCount = manaCounts[creatureCostColor];
                if (creatureCost > manaCount)
                {
                    errors.Add(Errors.MessageId.NOT_ENOUGH_MANA, creatureCost, manaCount);
                }
                else
                {
                    manaCounts[creatureCostColor] = manaCount - creatureCost;
                    creatures.Add(creature);
                }
            }
            else if (card.GetType() == typeof(Enchantment))
            {
            }
            else if (card.GetType() == typeof(Equipment))
            {
            }
            else if (card.GetType() == typeof(Instant))
            {
            }
            else if (card.GetType() == typeof(Land))
            {
                Land land = (Land)card;
                lands.Add(land);
                Mana mana = land.mana;
                manaCounts[mana.ManaColor] = manaCounts[mana.ManaColor] + mana.ManaCount;
            }
            else if (card.GetType() == typeof(Planeswalker))
            {
            }
            else if (card.GetType() == typeof(Sorcery))
            {
            }
            else
                errors.Add(Errors.MessageId.UNKNOWN_CARD_TYPE, card.GetType().Name);
        }
        public void Tap()
        {

        }
        public void UnTap()
        {

        }
        public void Upkeep()
        {

        }
        public override string ToString()
        {
            string description = "";
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
