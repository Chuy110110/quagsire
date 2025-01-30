namespace Cpsc370Final.Tests;

using Xunit;

public class PlayerTests
{
    [Fact]
    public void ConstructorSetsInitialBalance()
    {
        var player = new Player();
        Assert.True(player.Balance > 0);
    }

    [Fact]
    public void ResetPlayerStateForGameResetsHandAndStandingStatus()
    {
        var player = new Player();
        player.AddCardToHand(new Card("Hearts", "A"));
        player.AddCardToHand(new Card("Spades", "A"));

        player.MarkAsStandingForCurrentRound();

        player.ResetPlayerStateForGame();

        Assert.False(player.IsStandingForCurrentRound);
        Assert.True(player.Hand.Count == 0);
    }

    [Fact]
    public void AddCardToHandAddsCardToHand()
    {
        var player = new Player();
        var expectedCard = new Card("Hearts", "A");
        player.AddCardToHand(expectedCard);

        Assert.True(player.Hand.Count == 1);
        Assert.Equal(expectedCard, player.Hand.First());
    }

    [Fact]
    public void MarkAsStandingForCurrentRoundUpdatesState()
    {
        var player = new Player();
        player.MarkAsStandingForCurrentRound();
        Assert.True(player.IsStandingForCurrentRound);
    }
}