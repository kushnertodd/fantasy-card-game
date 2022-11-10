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
            Errors errors = new Errors();
            int count = 2;
            Mana mana1 = new Mana(Mana.Color.Red, count);
            Land land1 = new Land("land1", mana1);
            Deck deck1 = new Deck();
            deck1.Add(land1);
            Battlefield battlefield1 = new Battlefield(deck1);
            battlefield1.Play(land1, errors);
            if (errors.Have)
                Assert.Fail("play land1 failed " + errors);
            int manaCount1 = battlefield1.GetManaCount(Mana.Color.Red);
            Assert.AreEqual(manaCount1, count, "playing land1 gave mana count " +
                manaCount1 + " instead of " + count);

            Creature creature2 = new Creature(name: "creature2", cost: count + 1, costColor: Mana.Color.Red);
            battlefield1.Play(creature2, errors);
            if (errors.Have)
                Assert.Fail("play creature1 failed) " + errors);

            Creature creature1 = new Creature("creature1", count, Mana.Color.Red);
            battlefield1.Play(creature1, errors);
            if (errors.Have)
                Assert.Fail("play creature1 failed " + errors);
            int manaCount2 = battlefield1.GetManaCount(Mana.Color.Red);
            Assert.AreEqual(manaCount2, count, "playing creature1 gave mana count " +
                manaCount2 + " instead of 0");
            Console.WriteLine("test 1 succeeded");
        }
    }
}