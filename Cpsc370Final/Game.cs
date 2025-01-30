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
            
        }
    }

}