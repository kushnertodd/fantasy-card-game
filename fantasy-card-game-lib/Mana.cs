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
        // we'll skip colorless mana for now
        //public enum Color { Colorless, White, Green, Blue, Red, Black }
        public enum Color { White, Green, Blue, Red, Black }
        //later
        //public HashSet<Color> colors = new HashSet<Color>();
        public Color ManaColor { get; set; } // only one color for now

        public Mana() { }

        // call with: Mana mana = new Mana(new Color[] { Mana.Color.Red, Mana.Color.Blue, Mana.Color.Green });
        //public static Mana createMana(Color[] colors)
        //{
        //    Mana mana = new Mana();
        //    for (int i = 0; i < colors.Count(); i++)
        //    {
        //        mana.Add(colors[i]);
        //    }
        //    return mana;
        //}
        public Mana(Color color)
        {
            ManaColor=color;
        }
        public void Add(Color color)
        {
            //colors.Add(color);
            ManaColor = color;
        }
        public bool Match(Mana mana)
        {
            //ISet<Color> colorsInBoth = colors.Intersect(mana.colors);
            //if (colorsInBoth.Count > 0 || Colorless in colors)
            //    return true;
            //return false;
            //return (ManaColor == mana.ManaColor || mana.ManaColor == Color.Colorless);
            return (ManaColor == mana.ManaColor);
        }
        public string ToString(string prefix = "", string separator = " ", string suffix = "")
        {
            string description = this.GetType().Name + ":" + nameof(ManaColor);
            //string description = this.GetType().Name + ":";
            //foreach (Color color in colors)
            //    description += " " + color.ToString();
            return description;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
