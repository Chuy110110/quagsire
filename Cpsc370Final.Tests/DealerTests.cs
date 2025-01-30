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
    [Theory]
    [InlineData("2", "7", false)]
    [InlineData("2", "8", true)]
    public void Dealer_faceupandfacedown(string card1, string card2, bool turn)
    {
        var sut = new Dealer();
        
        var result = sut.FaceupFacedown(card1, card2, turn);
        if (turn == false)
        {
            Assert.Equal(card1, result.Item1);
            Assert.Equal("??", result.Item2);
        }

        if (turn == true)
        {
            Assert.Equal(card1, result.Item1);
            Assert.Equal(card2, result.Item2);
        }
    }
}