using System;
using System.Collections.Generic;

namespace Cpsc370Final;

// Extract console line reading into separate object
// to stub out while testing
public class ConsoleLineRetriever
{
    public virtual string? GetNextLine()
    {
        return Console.ReadLine();
    }
}

public class Game
{
    public Deck Deck { get; private set; }
    public Player Player { get; private set; }
    public bool RoundOver { get; private set; }

    private ConsoleLineRetriever consoleLineRetriever = new ConsoleLineRetriever();

    public Game()
    {
        InitializeGame();
    }

    public Game(ConsoleLineRetriever consoleLineRetriever)
    {
        this.consoleLineRetriever = consoleLineRetriever;
        InitializeGame();
    }

    private void InitializeGame()
    {
        Deck = new Deck();
        Player = new Player();
        RoundOver = false;
        NewRound();
    }


    public void NewRound()
    {
        RoundOver = false;
        Deck.ResetAndShuffle();
        Player.ResetPlayerStateForGame();
        DrawCard();
        DrawCard();
    }

    public void DrawCard()
    {
        Card card = Deck.DrawCard();
        Player.AddCardToHand(card);
        if (CalculateScore() > 21)
        {
            CheckAceAdjustment();
            if (CalculateScore() > 21)
            {
                RoundOver = true;
            }
        }
    }

    public int CalculateScore()
    {
        int score = 0;
        foreach (var card in Player.Hand)
        {
            score += card.Value;
        }

        return score;
    }

    public void CheckAceAdjustment()
    {
        foreach (var card in Player.Hand)
        {
            if (card.Rank == "A" && card.Value == 11)
            {
                card.swapAceValue(true);
                if (CalculateScore() <= 21)
                    break;
            }
        }
    }

    public bool PromptContinue()
    {
        Console.WriteLine("Do you want to play again? (yes/no)");
        var response = GetNextLine()?.Trim().ToLower();
        while (response != "yes" && response != "no")
        {
            Console.WriteLine("Invalid input. Please type 'yes' or 'no'.");
            response = consoleLineRetriever.GetNextLine().Trim().ToLower();
        }

        if (response == "yes")
        {
            return true;
        }
        else
        {
            Console.WriteLine("Thanks for playing!");
            return false;
        }
    }

    private string? GetNextLine()
    {
        return consoleLineRetriever.GetNextLine();
    }

    public string HitOrStand()
    {
        Console.WriteLine("Your current score: " + CalculateScore());
        while (!Player.IsStandingForCurrentRound)
        {
            Console.WriteLine("Do you want to hit or stand?");
            string action = consoleLineRetriever.GetNextLine().Trim().ToLower();

            switch (action)
            {
                case "hit":
                    DrawCard();
                    Console.WriteLine("Drawn: " + Player.Hand[^1]);
                    if (CalculateScore() > 21) Player.MarkAsStandingForCurrentRound();
                    break;
                case "stand":
                    Player.MarkAsStandingForCurrentRound();
                    RoundOver = true;
                    break;
                default:
                    Console.WriteLine("Invalid input, please enter 'hit' or 'stand'.");
                    continue;
            }
        }

        return Player.IsStandingForCurrentRound ? "stand" : "hit";
    }

    public void Play()
    {
        // While game is running
        // Ask the player if they want to start a round

        // This is one round:
        // Display player's first two cards
        // While player is not standing
            // Ask the player if they want to hit or stand
            // If hit, then a card to the player
            // If stand, then mark player as standing
        // Change to dealer's turn
            // Keep giving dealer cards until they have score >= 17
        // Compare player hand against dealer hand
            // If player wins, then they receive 2x their bet amount
            // If dealer wins, then player loses their bet amount

        // After the round is over
        // Check player balance
            // If player balance > 0, then ask to continue with current balance or to quit
            // If player balance <= 0, then ask if they want to restart with a new balance
            // or to quit

        // TODO: Tell player what their cards are at the start of round
        var isPlaying = true;

        while (isPlaying)
        {
            NewRound();
            while (!RoundOver)
            {
                if (!Player.IsStandingForCurrentRound)
                {
                    HitOrStand();
                }
                else
                {
                    // TODO: Write code which gives cards to dealer
                    Console.WriteLine("Final score: " + CalculateScore());
                    RoundOver = true;
                }
            }

            if (CalculateScore() == 21)
            {
                Console.WriteLine("Blackjack! You win!");
            }
            else if (CalculateScore() > 21)
            {
                Console.WriteLine("Bust! Game over.");
            }
            else
            {
                Console.WriteLine("You stand with a score of " + CalculateScore());
            }

            if (PromptContinue())
            {
            }
            else
            {
                isPlaying = false;
            }
        }

        Console.WriteLine("Thanks for playing!");
    }
}