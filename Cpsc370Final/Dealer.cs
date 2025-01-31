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
        if (hitOrStand(GetCardValueTotal()) == 0)
        {
            playHit();
            return "hit";
        }

        playStand();
        return "stand";
    }
    private int GetCardValueTotal()
    {
        for (int i = 0; i < dealerHand.Count; i++)
        {
            cardValueTotal += dealerHand[i].Value;
        }
        
        return cardValueTotal;
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
    
    public (string, string) FaceupFacedown(string card1, string card2, bool dealer_turn = false)
    {
        string dealer_card1 = card1;
        string dealer_card2 = card2;
        string facedown = "??";
        if (dealer_turn == false)
        {
            return (dealer_card1, facedown);
        }
        else
        {
            return (dealer_card1, dealer_card2);
        }
    }
}