using System;
using System.Collections.Generic;
using System.Text;

namespace EloRatingLibraryV1
{
    public class EloRatingOutput
    {
        public EloRatingOutput(EloRatingInput input)
        {
            this.SourceInput = input;
        }

        public EloRatingInput SourceInput { get; private set; }

        public double Player1NewPoints { get; set; }
        public double Player2NewPoints { get; set; }

        public double Player1PointsChange { get; set; }
        public double Player2PointsChange { get; set; }
    }
}
