using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    int faceValue;
    enum Suit
    {
        Spades,
        Clubs,
        Hearts,
        Diamonds,
        Trumps,
        Fool
    }

    Suit suit;

    public static IEnumerable<Card> GetDeck()
    {
        int[] values = new int [] { 14, 14, 14, 14, 21, 1 };
        for (int suit = (int)Suit.Spades; suit <= (int)Suit.Fool; suit++)
        {
            for (int value = 0; value < values[suit]; value++)
            {
                Card card = new Card();
                card.faceValue = value + 1;
                card.suit = (Suit)suit;
                yield return card;
            }
        }
    }

    public int Score()
    {
        int score = 0;
        switch (suit)
        {
            case Suit.Spades:
            case Suit.Clubs:
            case Suit.Hearts:
            case Suit.Diamonds:
                score = Mathf.Max(faceValue - 9, 1);
                break;
            case Suit.Trumps:
                score = (faceValue == 21 || faceValue == 1) ? 5 : 1;
                break;
            case Suit.Fool:
                score = 5;
                break;                 
        }
        return score;
    }

    public void Print()
    {
        Debug.Log($"Suit {suit} face value {faceValue} points {Score()}");
    }

    public bool LowerArcana()
    {
        return suit < Suit.Trumps;
    }

    public int CompareTo(Card card)
    {
        // comparing two lower arcana
        if (LowerArcana() && card.LowerArcana())
        {
            return faceValue - card.faceValue;
        }
        else if (LowerArcana() && !card.LowerArcana())
        {
            return -1;
        }
        else if (!LowerArcana() && card.LowerArcana())
        {
            return 1;
        }
        else // both major arcana
        {
            return faceValue - card.faceValue;
        }
    }
}
