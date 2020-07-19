using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    private List<Card> deck = new List<Card>();
    private List<Card> playerHand = new List<Card>();
    
    void Start()
    {
        deck = Deck.ShuffleDeck(Deck.GetDeck());
    }


    public void CardDeal(List<Card> playerHand)
    {
        playerHand.Clear();

        if (deck.Count < 5)
        {
            deck.Clear();
            deck = Deck.ShuffleDeck(Deck.GetDeck());
        }

        for (int i = 0; i < 5; i++)
        {
            playerHand.Add(Deck.GetCard(deck));
        }
        foreach (var card in playerHand)
        {
            Debug.Log($"{card.CardSuit}:{card.Number}");
        }
        Debug.Log(PokerHand.CardHand(playerHand));
    }
    public void CardChange(List<Card> playerHand, int changeNum)
    {
        playerHand.RemoveAt(changeNum);
        var changeCard = Deck.GetCard(deck);
        playerHand.Insert(changeNum, changeCard);
    }
}
        
