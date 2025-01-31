namespace Cpsc370Final;

using System;
using System.Collections.Generic;
using System.Linq;

public class Hand
{
    private List<Card> cards;

    public Hand()
    {
        cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public int GetHandValue()
    {
        int total = cards.Sum(card => (int)card.Rank);
        int aceCount = cards.Count(card => card.Rank == Rank.Ace);

        while (total > 21 && aceCount > 0)
        {
            total -= 10; // Adjust Ace value from 11 to 1 if needed
            aceCount--;
        }

        return total;
    }

    public bool IsBust() => GetHandValue() > 21;

    public void DisplayHand()
    {
        Console.WriteLine("Your hand:");
        foreach (var card in cards)
        {
            Console.WriteLine($"  - {card}");
        }
        Console.WriteLine($"Total Value: {GetHandValue()}");
    }

    public int CardCount => cards.Count;
}