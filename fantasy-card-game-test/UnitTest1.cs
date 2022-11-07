using Microsoft.VisualStudio.TestTools.UnitTesting;
using fantasy_card_game_lib;

namespace fantasy_card_game_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Deck deck = new Deck();
            deck.Add(new Creature("creature1"));
            deck.Add(new Creature("creature2"));
            deck.Add(new Artifact("artifact1"));
            deck.Add(new Artifact("artifact2"));
            deck.Add(new Equipment("equipment1"));
            deck.Add(new Equipment("equipment2"));
            deck.Add(new Enchantment("enchantment1"));
            deck.Add(new Enchantment("enchantment2"));
            int actual = deck.cards.Count;
            Assert.AreEqual(actual, 8, 0.001, "Deck.Add() failed");
        }
    }
}