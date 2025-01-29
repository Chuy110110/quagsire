namespace Cpsc370Final;

public class Dealer
{
    public int chooseAction(int total)
    {
        if (total >= 17)
        {
            return 1;
        }
        return 0;
    }
}