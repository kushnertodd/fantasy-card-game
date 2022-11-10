using Microsoft.VisualStudio.TestTools.UnitTesting;
using fantasy_card_game_lib;
using System.Net.Http.Headers;

namespace fantasy_card_game_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int count = 2;
            Mana mana1 = new Mana(Mana.Color.Red, count);
            Land land1 = new Land("land1", mana1);
            Deck deck1 = new Deck();
            deck1.Add(land1);
            Battlefield battlefield1 = new Battlefield(deck1);
            battlefield1.Play(land1);
            int manaCount = battlefield1.GetManaCount(Mana.Color.Red);
            Assert.AreEqual(manaCount, count, "land1 failed");
        }
    }
}