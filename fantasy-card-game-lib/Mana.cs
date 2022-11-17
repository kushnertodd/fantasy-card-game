using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

enum ManaTypeColor { Colorless, White, Red, Blue, Green, Black }


namespace fantasy_card_game_lib
{
    public class Mana
    {
        // we'll skip colorless mana for now
        //public enum Color { Colorless, White, Green, Blue, Red, Black }
        public enum ManaTypeColor { White, Green, Blue, Red, Black }
        //later
        //public HashSet<Color> colors = new HashSet<Color>();
        public ManaTypeColor ManaColor { get; set; } // only one color for now
        public int ManaCount { get; set; }

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
        public Mana(ManaTypeColor color, int manaCount = 1)
        {
            ManaColor=color;
            ManaCount=manaCount;
        }
        public void Add(ManaTypeColor color, int manaCount = 1)
        {
            //colors.Add(color);
            ManaColor = color;
            ManaCount = manaCount;
        }
        public bool Match(Mana mana)
        {
            //ISet<Color> colorsInBoth = colors.Intersect(mana.colors);
            //if (colorsInBoth.Count > 0 || Colorless in colors)
            //    return true;
            //return false;
            //return (ManaColor == mana.ManaColor || mana.ManaColor == Color.Colorless);
            return (ManaColor == mana.ManaColor && mana.ManaCount <= ManaCount);
        }
        public string ToString(string prefix = "", string separator = " ", string suffix = "")
        {
            string description = this.GetType().Name + ":" + nameof(ManaColor)+"/"+ManaCount;
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
