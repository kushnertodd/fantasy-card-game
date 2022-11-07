// See https://aka.ms/new-console-template for more inform

using fantasy_card_game;
using System;
using System.Xml.Linq;

internal class HelloWorld
{
    static void Main()
    {
        Board board = new Board("board1");
        board.Add(new Creature("creature1"));
        board.Add(new Creature("creature2"));
        board.Add(new Artifact("artifact1"));
        board.Add(new Artifact("artifact2"));
        board.Add(new Equipment("equipment1"));
        board.Add(new Equipment("equipment2"));
        board.Add(new Enchantment("enchantment1"));
        board.Add(new Enchantment("enchantment2"));

        Deck deck = new Deck();
        deck.Add(new Creature("creature1"));
        deck.Add(new Creature("creature2"));
        deck.Add(new Artifact("artifact1"));
        deck.Add(new Artifact("artifact2"));
        deck.Add(new Equipment("equipment1"));
        deck.Add(new Equipment("equipment2"));
        deck.Add(new Enchantment("enchantment1"));
        deck.Add(new Enchantment("enchantment2"));
        deck.Shuffle();

        Player player = new Player("player1", board, deck);
        player.Describe();
        Hand hand = deck.Deal(3);
        hand.Describe();
        deck.Describe();

    }
}