using System;
using System.Collections.Generic;

namespace fantasy_card_game_lib
{
    public enum CardType
    {
        Back,
        Creature,
        Land
    }
    public enum CardManaColor
    {
        Blue,
        Green,
        Red,
        WHite
    }
    public class Card
    {
        // Island.jpg	1	0	935	671
        public string FileName { get; set; }
        public CardType Type { get; set; }
        public CardManaColor ManaColor { get; set; }
        public int ManaColorCount { get; set; }
        public int ManaColorlessCount { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        private const int fieldCount = 7;

        public Card() { }
        public static Card CreateCard(List<string> list, int lineNo, Errors errors)
        {
            if (list.Count != fieldCount)
            {
                errors.Add(Errors.MessageId.MISC_TEXT, "line " + lineNo + ": wrong number of card fields");
                return null;
            }
            else
            {
                var card = new Card();
                string text = string.Empty;
                int index = 0;
                card.FileName = list[index++];
                text = list[index++];
                CardType cardType;
                if (!Enum.TryParse<CardType>(text, out cardType))
                {
                    errors.Add(Errors.MessageId.MISC_TEXT, "line " + lineNo + ": Unable to parse '" + text + "' as card type");
                    return null;
                }
                card.Type = cardType;
                text = list[index++];
                CardManaColor manaColor;
                if (!Enum.TryParse<CardManaColor>(text, out manaColor))
                {
                    errors.Add(Errors.MessageId.MISC_TEXT, "line " + lineNo + ": Unable to parse '" + text + "' as card color");
                    return null;
                }
                card.ManaColor = manaColor;
                text = list[index++];
                try
                {
                    card.ManaColorCount = Int32.Parse(text);
                }
                catch (FormatException)
                {
                    errors.Add(Errors.MessageId.MISC_TEXT, "line " + lineNo + ": Unable to parse '" + text + "' as mana color cost");
                    return null;
                }
                text = list[index++];
                try
                {
                    card.ManaColorlessCount = Int32.Parse(text);
                }
                catch (FormatException)
                {
                    errors.Add(Errors.MessageId.MISC_TEXT, "line " + lineNo + ": Unable to parse '" + text + "' as mana colorless cost");
                    return null;
                }
                text = list[index++];
                try
                {
                    card.Height = Int32.Parse(text);
                }
                catch (FormatException)
                {
                    errors.Add(Errors.MessageId.MISC_TEXT, "line " + lineNo + ": Unable to parse '" + text + "' as height");
                    return null;
                }
                try
                {
                    card.Width = Int32.Parse(list[index++]);
                }
                catch (FormatException)
                {
                    errors.Add(Errors.MessageId.MISC_TEXT, "line " + lineNo + ": Unable to parse '" + text + "' as width");
                    return null;
                }
                return card;
            }
        }
        public override string ToString()
        {
            return FileName
                + "\t" + Type
                + "\t" + ManaColor
                + "\t" + ManaColorCount
                + "\t" + ManaColorlessCount
                + "\t" + Height
                + "\t" + Width;
        }
    }
}
