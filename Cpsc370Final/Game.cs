using System;
using System.Collections.Generic;

namespace Cpsc370Final
{
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
        public bool GameOver { get; private set; }

        private ConsoleLineRetriever consoleLineRetriever = new ConsoleLineRetriever();

        public Game()
        {
            Deck = new Deck();
            Player = new Player();
            GameOver = false;
            NewRound();
        }

        public Game(ConsoleLineRetriever consoleLineRetriever)
        {
            this.consoleLineRetriever = consoleLineRetriever;
        }

    public void NewRound()
        {
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
                    GameOver = true;
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
                response = Console.ReadLine().Trim().ToLower();
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
                string action = Console.ReadLine().Trim().ToLower();

                switch (action)
                {
                    case "hit":
                        DrawCard();
                        Console.WriteLine("Drawn: " + Player.Hand[^1]);
                        if (CalculateScore() > 21) Player.MarkAsStandingForCurrentRound();
                        break;
                    case "stand":
                        Player.MarkAsStandingForCurrentRound();
                        GameOver = true;
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
            while (!GameOver)
            {
                if (!Player.IsStandingForCurrentRound)
                {
                    HitOrStand();
                }
                else
                {
                    Console.WriteLine("Final score: " + CalculateScore());
                    GameOver = true;
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
                NewRound();
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
            }
        }
    }
}