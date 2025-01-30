namespace Cpsc370Final;

public class Player
{
    private const int StartingBalance = 1000;

    private int balance;
    public List<Card> hand { get; private set; }
    private int score;

    private bool _isStandingForCurrentRound = false;

    public Player()
    {
        balance = StartingBalance;
        hand = new List<Card>();
    }

    public void AddCardToHand(Card card)
    {
    }

    public void ClearHand()
    {
    }

    public void MarkAsStandingForCurrentRound()
    {
    }
}