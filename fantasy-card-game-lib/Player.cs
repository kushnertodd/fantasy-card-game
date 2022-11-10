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
        public int LifePoints { get; set; }
        public int CommanderDamage { get; set; }
        public Board board;

        public Player(string name, Board board)
        {
            Name = name;
            LifePoints = 40;
            CommanderDamage = 0;
            this.board = board;
        }
        public Planeswalker SelectCommander(Cards cards, string name)
        {
            foreach (Card card in cards.cards)
            {
                if (card.GetType() == typeof(Planeswalker) && card.Name == name)
                {
                    return (Planeswalker)card;
                }
            }
            return null!;
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
