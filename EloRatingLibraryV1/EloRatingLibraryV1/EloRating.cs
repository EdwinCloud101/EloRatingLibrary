using System;
using System.Collections.Generic;
using System.Text;

namespace EloRatingLibraryV1
{
    public class EloRating
    {

        public EloRating(EloRatingConfig config)
        {
            this.Config = config;
        }

        public EloRatingConfig Config { get; private set; }

        public EloRatingOutput RankIt(EloRatingInput input)
        {
            var victory = input.Victory;

            double flatScore = Config.FlatScore;
            double score = Config.Factor;

            var output = new EloRatingOutput(input);

            if (victory == EloRatingVictoryEnum.FirstPlayerWins)
            {
                score = 32 - 1 / (1 + Math.Pow(10, ((input.Player2Points - input.Player1Points) / flatScore))) * 32;
                output.Player1NewPoints = input.Player1Points + score;
                output.Player2NewPoints = input.Player2Points - score;
                output.Player1PointsChange = score;
                output.Player2PointsChange = score * -1;
            }
            else if (victory == EloRatingVictoryEnum.SecondPlayerWins)
            {
                score = 32 - 1 / (1 + Math.Pow(10, ((input.Player1Points - input.Player2Points) / flatScore))) * 32;
                output.Player1NewPoints = input.Player1Points - score;
                output.Player2NewPoints = input.Player2Points + score; ;
                output.Player1PointsChange = score * -1;
                output.Player2PointsChange = score;
            }
            else if (victory == EloRatingVictoryEnum.Draw)
            {
                score = 0;
                output.Player1NewPoints = input.Player1Points;
                output.Player2NewPoints = input.Player2Points;
                output.Player1PointsChange = 0;
                output.Player2PointsChange = 0;
            }

            return output;
        }
    }
}
