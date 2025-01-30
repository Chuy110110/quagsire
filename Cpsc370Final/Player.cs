namespace Cpsc370Final;

public class Player
{
    private const int StartingBalance = 1000;

    public List<Card> Hand { get; private set; }
    public int Balance;

    public bool IsStandingForCurrentRound { get; private set; }

    public Player()
    {
        Balance = StartingBalance;
        Hand = new List<Card>();

        ResetPlayerStateForGame();
    }

    public void ResetPlayerStateForGame()
    {
        // Doesn't reset the balance, just the other attributes
        Hand.Clear();
        IsStandingForCurrentRound = false;
    }

    public void AddCardToHand(Card card)
    {
    }

    public void ClearHand()
    {
    }

    // TODO: Add more ways to work with standing state
    public void MarkAsStandingForCurrentRound()
    {
        IsStandingForCurrentRound = true;
    }
}