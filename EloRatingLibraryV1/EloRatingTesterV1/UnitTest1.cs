using Microsoft.VisualStudio.TestTools.UnitTesting;
using EloRatingLibraryV1;
using System;

namespace EloRatingTesterV1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BasicRankIt()
        {

            //for (int i = 0; i < 500; i++)
            {
                var eloRatingConfig = new EloRatingConfig();
                eloRatingConfig.FlatScore = 400;
                eloRatingConfig.Factor = 120;

                var eloRatingInput = new EloRatingInput(EloRatingVictoryEnum.FirstPlayerWins);
                eloRatingInput.Player1Points = 1700;
                eloRatingInput.Player2Points = 1300;

                var eloRating = new EloRating(eloRatingConfig);
                var eloRatingOutput = eloRating.RankIt(eloRatingInput);

                Assert.IsTrue(eloRatingConfig.FlatScore > 0 && eloRatingConfig.Factor > 0);
                Assert.IsTrue(eloRatingInput.Victory == EloRatingVictoryEnum.FirstPlayerWins);
                Assert.IsTrue(eloRating.Config == eloRatingConfig);

                Assert.IsTrue(eloRatingOutput.SourceInput.Player1Points == eloRatingInput.Player1Points);
                Assert.IsTrue(eloRatingOutput.SourceInput.Player2Points == eloRatingInput.Player2Points);

                Assert.IsTrue(eloRatingOutput.Player1NewPoints > eloRatingInput.Player1Points);
                Assert.IsTrue(eloRatingOutput.Player2NewPoints < eloRatingInput.Player2Points);

                int i = 0;
                Console.WriteLine($"interatction {i} Player 1 Input {eloRatingInput.Player1Points} --- Player1 Output {eloRatingOutput.Player1NewPoints}");
                Console.WriteLine($"interatction {i} Player 2 Input {eloRatingInput.Player2Points} --- Player2 Output {eloRatingOutput.Player2NewPoints}");
                Console.WriteLine("------");
            }
        }
    }
}