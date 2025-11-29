using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class TestDeck : MonoBehaviour
{
    void Start()
    {
        Deck deck = new();
        deck.Shuffle();

        List<List<Card>> hands = new List<List<Card>>();
        for (int player = 0; player < 3; player++)
        {
            hands.Add(new List<Card>());
        }

        for (int i = 0; i < 5; i++)
        {
            // Deal 5 cards to each player
            for (int player = 0; player < 3; player++)
            {
                for (int cards = 0; cards < 5; cards++)
                {
                    hands[player].Add(deck.Deal());
                }
            }
        }

        // Add the 3 remaining cards to the dealer
        for (int i = 0; i < 3; i++)
        {
            hands[0].Add(deck.Deal());
        }

        // Discard the lowest 3 value cards to the discard pile
        hands[0].Sort((a, b) => a.CompareTo(b));
        for (int i = 0; i < 3; i++)
        {
            Card card = hands[0][0];
            hands[0].RemoveAt(0);
            deck.Discard(card);
        }

        deck.Print();
    }
}
