namespace Cpsc370Final.Tests;

using Xunit;

public class HandTests
{
    [Fact]
    public void Hand_StartsEmpty()
    {
        var hand = new Hand();
        Assert.Equal(0, hand.CardCount);
    }

    [Fact]
    public void Hand_CanAddCards()
    {
        var hand = new Hand();
        hand.AddCard(new Card(Suit.Hearts, Rank.Ace));
        Assert.Equal(1, hand.CardCount);
    }

    [Fact]
    public void Hand_CalculatesValue_Correctly()
    {
        var hand = new Hand();
        hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
        hand.AddCard(new Card(Suit.Diamonds, Rank.Seven));
        
        Assert.Equal(17, hand.GetHandValue());
    }

    [Fact]
    public void Hand_Aces_AdjustValue_WhenOver21()
    {
        var hand = new Hand();
        hand.AddCard(new Card(Suit.Spades, Rank.Ace));
        hand.AddCard(new Card(Suit.Hearts, Rank.Ace));
        hand.AddCard(new Card(Suit.Clubs, Rank.Nine));

        Assert.Equal(21, hand.GetHandValue());
    }

    [Fact]
    public void Hand_DetectsBust()
    {
        var hand = new Hand();
        hand.AddCard(new Card(Suit.Hearts, Rank.King));
        hand.AddCard(new Card(Suit.Clubs, Rank.Queen));
        hand.AddCard(new Card(Suit.Diamonds, Rank.Five));

        Assert.True(hand.IsBust());
    }
}