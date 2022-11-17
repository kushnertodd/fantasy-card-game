using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Player
    {
        public string Name { get; set; }
        public int CommanderDamage { get; set; }
        public int LifePoints { get; set; }
        public Battlefield battlefield;
        public Creature commander;
        public Hand hand;

        public Player(string name, Deck deck, Errors errors)
        {
            Name = name;
            LifePoints = 40;
            CommanderDamage = 0;
            battlefield = new Battlefield(deck);
            commander = deck.SelectCommander(errors);
            hand = deck.DrawHand(7);
        }
        public void AddCommanderDamage(int damage)
        {
            CommanderDamage += damage;
        }
        public void AddLife(int life)
        {
            LifePoints += life;
        }
        public void RemoveLife(int life)
        {
            LifePoints -= life;
        }
        public void StartTurn()
        {
            Errors errors= new Errors();
            battlefield.UnTap();
            battlefield.Upkeep();
            Card card = hand.Select(battlefield, errors)!;
            if (!errors.Have)
            {
                battlefield.Play(card, errors);
            }
        }
        public override string ToString()
        {
            return Name;
        }
        public void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + ToString());
        }
    }
}
