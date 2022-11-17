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
        //public enum ManaTypeColor { Colorless, White, Green, Blue, Red, Black }
        public enum ManaTypeColor { White, Green, Blue, Red, Black }
        //later
        //public HashSet<ManaTypeColor> colors = new HashSet<ManaTypeColor>();
        public ManaTypeColor ManaColor { get; set; } // only one color for now
        public int ManaCount { get; set; }

    public Mana() { }

        // call with: Mana mana = new Mana(new ManaTypeColor[] { Mana.ManaTypeColor.Red, Mana.ManaTypeColor.Blue, Mana.ManaTypeColor.Green });
        //public static Mana createMana(ManaTypeColor[] colors)
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
            //ISet<ManaTypeColor> colorsInBoth = colors.Intersect(mana.colors);
            //if (colorsInBoth.Count > 0 || Colorless in colors)
            //    return true;
            //return false;
            //return (ManaColor == mana.ManaColor || mana.ManaColor == ManaTypeColor.Colorless);
            return (ManaColor == mana.ManaColor && mana.ManaCount <= ManaCount);
        }
        public string ToString(string prefix = "", string separator = " ", string suffix = "")
        {
            string description = this.GetType().Name + ":" + nameof(ManaColor)+"/"+ManaCount;
            //string description = this.GetType().Name + ":";
            //foreach (ManaTypeColor color in colors)
            //    description += " " + color.ToString();
            return description;
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
