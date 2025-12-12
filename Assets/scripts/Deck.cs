using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Deck
{
    List<Card> cards;
    public Deck()
    {
        cards = new List<Card>(Card.GetDeck());
    }

    // Copy constructor: this makes a new deck by copying all of the card from the given list
    public Deck(List<Card> cards)
    {
        this.cards = new List<Card>(cards);
    }

    public bool IsEmpty()
    {
        return cards.Count == 0;
    }

    public Card RandomCard()
    {
        Card card = cards[Random.Range(0, cards.Count)];
        cards.Remove(card);
        return card;
    }

    public void Print()
    {
        foreach (Card card in cards)
        {
            card.Print();
        }
    }

    public void Shuffle()
    {
        Deck unshuffled = new Deck(cards);
        cards.Clear();
        while (!unshuffled.IsEmpty())
        {
            Card card = unshuffled.RandomCard();
            cards.Add(card);
        }
    }

    public Card Deal()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    public void Discard(Card card)
    {
        cards.Add(card);
    }
}
