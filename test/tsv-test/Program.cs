using System.ComponentModel;

namespace TSV_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Errors errors = new Errors();
            Cards cardList = Cards.CreateCards("cards.db", errors);
            if (errors.Have())
            {
                Console.WriteLine("errors:\n" + errors.ToString());
            } else
            {
                Console.WriteLine("cards:\n" + cardList.ToString());
            }
            //List<List<string>> lines = FileIO.ReadDelimitedFile("cards.db", errors);
            //if (errors.Have())
            //    Console.WriteLine("errors: " + errors.ToString());
            //else
            //    Console.WriteLine("read " + lines.Count + " lines");
        }
    }
}