namespace Cpsc370Final;


public class Dealer
{
    private int cardValueTotal;
    private List<Card> dealerHand;
    private Deck deck;
    
    public Dealer()
    {
        deck = new Deck();
        dealerHand = [];
    }
    public Card DealCard()
    {
        Card card = deck.DrawCard();
        
        return card;
    }

    public void ShuffleDeck()
    {
        deck.ResetAndShuffle();
    }

    public string chooseAction()
    {
        if (hitOrStand(cardValueTotal) == 0)
        {
            playHit();
            return "hit";
        }

        playStand();
        return "stand";
    }
    private void GetCardValueTotal()
    {
        
    }

    private void playHit()
    {
        Card newCard = deck.DrawCard();
        dealerHand.Add(newCard);
    }
    private void playStand()
    {
        return;
    }

    public int hitOrStand(int total)
    {
        if (total >= 17)
        {
            return 1;
        }
        return 0;
    }

}