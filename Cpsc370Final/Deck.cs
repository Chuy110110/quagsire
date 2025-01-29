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
    
}