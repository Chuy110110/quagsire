using System;
using System.Collections.Generic;
namespace Cpsc370Final;

// Added temporary placeholder card class
public class Card
{
    public string Suit { get; private set; }
    public string Rank { get; private set; }

    public Card(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}
public class Deck
{
    private List<Card> cards;
    private Random random = new();

    public Deck()
    {
        ResetAndShuffle();
    }

    public Deck(Random random, List<Card> cards)
    {
        this.random = random;
        this.cards = cards;
        ResetAndShuffle();
    }

    public void ResetAndShuffle()
    {
        cards = new List<Card>();
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                cards.Add(new Card(suit, rank));
            }
        }

        Shuffle();
    }

    private void Shuffle()
    {
        // Fisher-Yates Shuffle
        for (int n = cards.Count - 1; n > 0; --n)
        {
            int k = random.Next(n + 1);
            Card temp = cards[n];
            cards[n] = cards[k];
            cards[k] = temp;
        }
    }

    public Card DrawCard()
    {
        if (cards.Count > 0)
        {
            Card cardToDraw = cards[0];
            cards.RemoveAt(0);
            return cardToDraw;
        }
        else
        {
            throw new InvalidOperationException("No cards left in the deck.");
        }
    }
}