using System;
using System.Collections.Generic;

namespace Cpsc370Final
{
    public class Game
    {
        public Deck Deck { get; private set; }
        public List<Card> Playerhan { get; private set; }
        public int PlayerScore { get; private set; }
        public bool GameOver { get; private set; }

        public Game()
        {
            
        }
    }

}