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
        // Arrange
        var player = new Player();
        player.AddCardToHand(new Card("Hearts", "A"));
        player.AddCardToHand(new Card("Spades", "A"));

        player.MarkAsStandingForCurrentRound();

        player.ClearHand();

        Assert.False(player.IsStandingForCurrentRound);
        Assert.True(player.Hand.Count == 0);
    }
}