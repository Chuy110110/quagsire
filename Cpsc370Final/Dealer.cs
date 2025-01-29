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
}