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
            if (!battlefield1.Play(land1))
                Assert.Fail("play land1 failed");
            int manaCount1 = battlefield1.GetManaCount(Mana.Color.Red);
            Assert.AreEqual(manaCount1, count, "playing land1 gave mana count " +
                manaCount1 + " instead of " + count);
            Creature creature1 = new Creature("creature1", count, Mana.Color.Red);
            if (!battlefield1.Play(creature1)) Assert.Fail("play creature1 failed)");
            int manaCount2 = battlefield1.GetManaCount(Mana.Color.Red);
            Assert.AreEqual(manaCount2, count, "playing creature1 gave mana count " +
                manaCount2 + " instead of 0");
        }
    }
}