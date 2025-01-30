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

    [Theory]
    [InlineData(0, "hit")]
    [InlineData(1, "stand")]
    public void Dealer_choosesAction_usingHitOrStand(int actionValue, string expected)
    {
        var sut = new Dealer();
        
        var result = sut.chooseAction();
        
        Assert.Equal(result, expected);
    }
}