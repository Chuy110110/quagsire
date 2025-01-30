namespace Cpsc370Final.Tests;

public class Deck_tests
{
    [Fact]
    public void ResetAndShuffleConstructsRandomizedCardList()
    {
        const int seed = 64;

        var random = new Random(seed);
        var cards = new List<Card>();

        var deck = new Deck(random, cards);
        deck.ResetAndShuffle();

        const int numCards = 52;

        Assert.Equal(numCards, cards.Count);
    }

    [Fact]
    public void DrawCardDrawsFirstCardFromDeck()
    {
        // Arrange
        const int seed = 64;

        var random = new Random(seed);
        var cards = new List<Card>();

        var deck = new Deck(random, cards);
        deck.ResetAndShuffle();
        // At this point, cards should have 52 cards

        // Act
        var expectedCard = cards[0];
        var card = deck.DrawCard();

        // Assert
        Assert.Equal(expectedCard, card);
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