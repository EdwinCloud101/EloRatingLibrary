using System;
using System.Collections.Generic;
using System.Text;

namespace EloRatingLibraryV1
{
    public enum EloRatingVictoryEnum
    {
        None,
        FirstPlayerWins,
        SecondPlayerWins,
        Draw
    }

    public class EloRatingInput
    {
        public EloRatingInput(EloRatingVictoryEnum victory)
        {
            this.Victory = victory;
        }

        public EloRatingVictoryEnum Victory { get; private set; }

        public double Player1Points { get; set; }
        public double Player2Points { get; set; }
    }
}