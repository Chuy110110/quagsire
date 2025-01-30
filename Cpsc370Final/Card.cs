namespace Cpsc370Final;

public class Card
{
    public string Suit { get; }
    public string Rank { get; }
    public string Color { get; }
    //@color for in case we add funny rules later
    public int Value { get; private set; }

    public Card(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
        Value = CardValues(rank);
    }

    private int CardValues(string rank)
    {
        return rank switch
        {
            "2" => 2,
            "3" => 3,
            "4" => 4,
            "5" => 5,
            "6" => 6,
            "7" => 7,
            "8" => 8,
            "9" => 9,
            "10" => 10,
            "J" => 10,
            "Q" => 10,
            "K" => 10,
            "A" => 11,
            _ => throw new ArgumentException("Invalid card rank")
        };
    }

    public void swapAceValue(bool useLowerValue)
    {
        if (Rank == "A")
        {
            Value = useLowerValue ? 1 : 0;
        }
    }
    
    public override string ToString()
    {
        return $"{Rank} of {Suit} (Value: {Value})";
    }

    public static void TestingCard()
    {
        
        Console.WriteLine("testing the cards . . . ");
        
        //creates cards
        Card card1 = new Card("Hearts", "A");
        Card card2 = new Card("Spades", "10");
        Card card3 = new Card("Diamonds", "K");
        Card card4 = new Card("Clubs", "5"); 
        
        //prints cards
        Console.WriteLine(card1);
        Console.WriteLine(card2);
        Console.WriteLine(card3);
        Console.WriteLine(card4); 
        
        //Test Ace Value Adjustment
        Console.WriteLine("testing the swapAeValue function . . . ");
        card1.swapAceValue(true);  // Change Ace value to 1
        Console.WriteLine(card1);
    }
}