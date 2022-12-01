using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSV_test
{
     class Cards
    {
        private List<Card> cardList = new List<Card>();

        public Cards() { }
        public static Cards CreateCards(string fileName, Errors errors)
        {
            Cards cards = new Cards();
            List<List<string>> lines = FileIO.ReadDelimitedFile(fileName, errors);
            for (int lineNo = 0; lineNo < lines.Count; lineNo++)
            {
                List<string> line = lines[lineNo];
                Card card = Card.CreateCard(line, lineNo, errors);
                if (errors.Have())
                    return null;
                cards.Add(card);
            }
            return cards;
        }
        public void Add(Card card)
        {
            cardList.Add(card);
        }
        public override string ToString()
        {
            string text = string.Empty;
            foreach (Card card in cardList)
            {
                text += card.ToString() + "\n";
            }
            return text;
        }
    }
}
