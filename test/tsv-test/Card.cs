using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TSV_test
{
    enum CardType
    {
        Creature,
        Land
    }
    enum CardColor
    {
        Blue,
        Green,
        Red,
        WHite
    }
    internal class Card
    {
        // Island.jpg	1	0	935	671
        private string fileName = "";
        private CardType cardType;
        private CardColor cardColor;
        private int manaColorCount;
        private int manaColorlessCount;
        private int height;
        private int width;
        private const int fieldCount = 7;

        public Card() { }
        public static Card CreateCard(List<string> list, int lineNo, Errors errors)
        {
            if (list.Count != fieldCount)
            {
                errors.Add("line " + lineNo + ": wrong number of card fields");
                return null;
            }
            else
            {
                var card = new Card();
                string text = string.Empty;
                int index = 0;
                card.fileName = list[index++];
                text = list[index++];
                if (!Enum.TryParse<CardType>(text, out card.cardType))
                {
                    errors.Add("line " + lineNo + ": Unable to parse '" + text + "' as card type");
                    return null;
                }
                text = list[index++];
                if (!Enum.TryParse<CardColor>(text, out card.cardColor))
                {
                    errors.Add("line " + lineNo + ": Unable to parse '" + text + "' as card color");
                    return null;
                }
                text = list[index++];
                try
                {
                    card.manaColorCount = Int32.Parse(text);
                }
                catch (FormatException)
                {
                    errors.Add("line " + lineNo + ": Unable to parse '" + text + "' as mana color cost");
                    return null;
                }
                text = list[index++];
                try
                {
                    card.manaColorlessCount = Int32.Parse(text);
                }
                catch (FormatException)
                {
                    errors.Add("line " + lineNo + ": Unable to parse '" + text + "' as mana colorless cost");
                    return null;
                }
                text = list[index++];
                try
                {
                    card.height = Int32.Parse(text);
                }
                catch (FormatException)
                {
                    errors.Add("line " + lineNo + ": Unable to parse '" + text + "' as height");
                    return null;
                }
                try
                {
                    card.width = Int32.Parse(list[index++]);
                }
                catch (FormatException)
                {
                    errors.Add("line " + lineNo + ": Unable to parse '" + text + "' as width");
                    return null;
                }
                return card;
            }
        }
        public override string ToString()
        {
            return fileName 
                + "\t" + cardType 
                + "\t" + cardColor 
                + "\t" + manaColorCount 
                + "\t" + manaColorlessCount 
                + "\t" + height 
                + "\t" + width;
        }
    }
}
