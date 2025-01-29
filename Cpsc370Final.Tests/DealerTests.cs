namespace Cpsc370Final.Tests;

public class DealerTests
{
    [Theory]
    [InlineData(18,1)]
    [InlineData(16,0)]
    public void Dealer_choosesHitOrStand_fromCardTotal(int total, int expected)
    {
        var sut = new Dealer();
        
        var result = sut.hitOrStand(total);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Dealer_choosesAction_usingHitOrStand()
    {
        var sut = new Dealer();
        
        var result = sut.chooseAction();
        
        Assert.
    }

    [Fact]
    public void Dealer_canShuffle()
    {
        var sut = new Dealer();

        var result = shuffleDeck();
        
        
    }
}