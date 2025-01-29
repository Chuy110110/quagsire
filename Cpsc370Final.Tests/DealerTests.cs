namespace Cpsc370Final.Tests;

public class DealerTests
{
    [Theory]
    [InlineData(18,1)]
    [InlineData(16,0)]
    public void Dealer_choosesAction_fromCardTotal(int total, int expected)
    {
        var sut = new Dealer();
        
        var result = sut.chooseAction(total);
        
        Assert.Equal(expected, result);
    }
}