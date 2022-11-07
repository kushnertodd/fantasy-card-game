// See https://aka.ms/new-console-template for more inform

using fantasy_card_game_lib;
using System;
using System.Xml.Linq;

internal class HelloWorld
{
    static void Main()
    {
        Board board1 = new Board("board1");
        board1.Add(new Creature("creature1"));
        board1.Add(new Creature("creature2"));
        board1.Add(new Artifact("artifact1"));
        board1.Add(new Artifact("artifact2"));
        board1.Add(new Equipment("equipment1"));
        board1.Add(new Equipment("equipment2"));
        board1.Add(new Enchantment("enchantment1"));
        board1.Add(new Enchantment("enchantment2"));

        Deck deck = new Deck();
        deck.Add(new Creature("creature1", isCommander: true));
        deck.Add(new Creature("creature2", isPlanesWalter: true));
        deck.Add(new Artifact("artifact1"));
        deck.Add(new Artifact("artifact2"));
        deck.Add(new Equipment("equipment1"));
        deck.Add(new Equipment("equipment2"));
        deck.Add(new Enchantment("enchantment1"));
        deck.Add(new Enchantment("enchantment2"));
        deck.Shuffle();
        Board board2 = new Board("board2");
        Table table = new Table("table1");
        table.Add(board1);
        table.Add(board2);
        table.Describe("table: ");

        Player player = new Player("player1", board1, deck);
        player.Describe("player: ");
        Hand hand = deck.Deal(3);
        hand.Describe("hand: ");
        deck.Describe("deck: ");
        Creature commander1 = player.SelectCommander(deck, "creature1");
        if (commander1 != null)
            commander1.Describe();
        else
            Console.WriteLine("cannot find commander creature1");
    }
}