using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

enum Color { Colorless, White, Red, Blue, Green, Black }


namespace fantasy_card_game_lib
{
    public class Mana
    {
        public enum Color { Colorless, White, Red, Blue, Green, Black }
        public ISet<Color> colors;

        public Mana() { }

        // call with: Mana mana = new Mana(new int[] { Red, Blue, Green });
        public static Mana createMana(Color[] _colors)
        {
            Mana mana = new Mana();
            for (int i = 0; i < _colors.Count(); i++)
            {
                mana.Add(_colors[i]);
            }
            return mana;
        }
        public static Mana createMana(Color _color)
        {
            Mana mana = new Mana();
            mana.Add(_color);
            return mana;
        }
        public void Add(Color color)
        {
            colors.Add(color);
        }
        public string toString()
        {
            string description = this.GetType().Name + ":";
            foreach (Color color in colors) 
                description += " " + color.ToString();
            return description;
        }
        public  void Describe(string prefix = "")
        {
            Console.WriteLine(prefix + toString());
        }
    }
}
