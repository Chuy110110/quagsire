namespace Cpsc370Final.Tests;

public class Deck_tests
{
    [Fact]
    public void ResetAndShuffleConstructsRandomizedCardList()
    {
    }

    [Fact]
    public void DrawCardDrawsFirstCardFromDeck()
    {

    }

    [Fact]
    public void DrawCardThrowsCorrectExceptionAfterDrawingAllCards()
    {
        var deck = new Deck();

        const int numCards = 52;
        for (int i = 0; i < numCards; i++)
        {
            deck.DrawCard();
        }

        Assert.Throws<InvalidOperationException>(() => deck.DrawCard());
    }
}