using System.Collections;
using UnityEngine;

public class Cards
{
    // value of the cards is a int variable 
    int faceValue;

    // enumeration type, is a value type set of named constants, so the enum type is Suit and the constants are spades, clubs, etc...
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
        int[] values = new int[] { 14, 14, 14, 14, 21, 1 };
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
        else if (LowerArcana())
        {
            return -1;
        }
        else if (card.LowerArcana())
        {
            return 1;
        }
        else // both major arcana
        {
            return faceValue - card.faceValue;
        }
    }









}
