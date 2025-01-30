using System;
using System.Collections.Generic;

namespace Cpsc370Final
{
    public class Game
    {
        public Deck Deck { get; private set; }
        public List<Card> PlayerHand { get; private set; }
        public int PlayerScore { get; private set; }
        public bool GameOver { get; private set; }

        public Game()
        {
            Deck = new Deck();
            PlayerHand = new List<Card>();
            GameOver = false;
            NewRound();
        }

        public void NewRound()
        {
            Deck.ResetAndShuffle();
            PlayerHand.Clear();
            PlayerScore = 0;
            GameOver = false;
            DrawCard();
            DrawCard();
        }

        public void DrawCard()
        {
            Card card = Deck.DrawCard();
            PlayerHand.Add(card);
            PlayerScore += card.Value;
            CheckAceAdjustment();
            if (PlayerScore > 21)
            {
                GameOver = true;
            }
        }

        public void CheckAceAdjustment()
        {
            if (PlayerScore > 21)
            {
                foreach (var card in PlayerHand)
                {
                    if (card.Rank == "A" && card.Value == 11)
                    {
                        card.swapAceValue(true);
                        PlayerScore -= 10;
                        if (PlayerScore <= 21)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public bool PromptContinue()
        {
            Console.WriteLine("Do you want to play again? (yes/no)");
            string response = Console.ReadLine().Trim().ToLower();
            if (response == "yes")
            {
                NewRound();
                return true;
            }

            return false;
        }

        public string HitOrStand()
        {
            while (true)
            {
                Console.WriteLine("Do you want to hit or stand?");
                string action = Console.ReadLine().Trim().ToLower();

                switch (action)
                {
                    case "hit":
                        DrawCard();
                        return "hit";
                    case "stand":
                        GameOver = true;
                        return "stand";
                    default:
                        Console.WriteLine("Invalid input, please enter 'hit' or 'stand'.");
                        continue;
                }
            }
        }
    }

}