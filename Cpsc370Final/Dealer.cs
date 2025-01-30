namespace Cpsc370Final;

public class Dealer
{

    public void chooseAction()
    {
        
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