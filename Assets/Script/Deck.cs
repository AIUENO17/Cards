using System;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    public static List<Card> GetDeck()
    {
        var deck = new List<Card>();

        for (int i = 0; i < Card.CardMax; i++)
        {
            deck.Add(new Card(Card.CardSuitjudge(i), Card.CardNumJudge(i),i));
        }
        return deck;
    }



    public static List<Card> ShuffleDeck(List<Card> deck)
    {
        var shuffleDeck = deck.OrderBy(Card => Guid.NewGuid()).ToList();
        return shuffleDeck;
    }
    public static Card GetCard(List<Card> deck)
    {
        var card = deck.First();
        deck.RemoveAt(0);
        return card;
    }
}