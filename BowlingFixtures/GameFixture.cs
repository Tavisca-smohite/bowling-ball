using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingFixtures
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void TotalFrameCountShouldBeLessThanOrEqualToTen()
        {

            var obj = new Bowling.Game();
            for (int i = 0; i < 10; i++)
            {
                obj.Roll(7);
                obj.Roll(3);
                int track = obj.TrackOfThrows[i].Aggregate((a, b) => b + a);
                if (track > 10)
                {
                    Assert.Fail("invalid inputs: total pins in a frame cant be more than 10");
                }
            }
            
        }

        [TestMethod]
        public void AllStrikes()
        {

            var obj = new Bowling.Game();
            int finalscore = 0;
            for (int i = 0; i < 12; i++)
            {
                obj.Roll(10);
                finalscore = obj.GetScore();
            }
            if (finalscore != 300)
            {
                Assert.Fail("test failed for all strikes condition");
            }


        }

        [TestMethod]
        public void AllGutters()
        {

            var obj = new Bowling.Game();
            int FinalScore = 0;
            for (int i = 0; i < 20; i++)
            {
                obj.Roll(0);
                FinalScore = obj.GetScore();
            }
            if (FinalScore != 0)
            {
                Assert.Fail("test failed for all gutter condition");
            }

        }

        [TestMethod]
        public void AllSpares()
        {

            var obj = new Bowling.Game();
            int FinalScore = 0;
            for (int i = 0; i < 21; i++)
            {
                obj.Roll(5);
                FinalScore = obj.GetScore();
            }
            if (FinalScore != 150)
            {
                Assert.Fail("test failed for all spares condition");
            }

        }

        [TestMethod]
        public void Mixture()
        {

            var obj = new Bowling.Game();
            int FinalScore = 0;
            obj.Roll(5); obj.Roll(5);
            obj.Roll(4); obj.Roll(3);
            obj.Roll(10);
            obj.Roll(2); obj.Roll(3);
            obj.Roll(0); obj.Roll(8);
            obj.Roll(1); obj.Roll(4);
            obj.Roll(7); obj.Roll(3);
            obj.Roll(2); obj.Roll(2);
            obj.Roll(1); obj.Roll(1);
            obj.Roll(10);
            obj.Roll(2); obj.Roll(3);

            for (int i = 0; i < 21; i++)
            {

                FinalScore = obj.GetScore();
            }
            if (FinalScore != 87)
            {
                Assert.Fail("test failed for all spares condition");
            }

        }


        [TestMethod]
        public void AllSparesWithZeroAndTenArePinsPerFrame()
        {
            int FinalScore = 0;
            var obj = new Bowling.Game();
            for (int i = 0; i < 11; i++)
            {
                obj.Roll(0);
                obj.Roll(10);
                FinalScore = obj.GetScore();
            }

            if (FinalScore != 100)
            {
                Assert.Fail("test failed for all spares condition");
            }


            



        }


    }
}
