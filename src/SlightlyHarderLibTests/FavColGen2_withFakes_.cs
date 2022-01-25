using System;
using System.Linq;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pose;

namespace SlightlyHarderLib.Tests
{
    [TestClass]
    public class FavColGen2_withFakes_Pose_
    {
        //	  **************************************
        //	 *										*
        //	 *            DONT USE FAKES			*
        //	 *										*
        //	   *************************************/

        [TestMethod()]
        [Ignore]
        public void On_Tuesday_Should_Be_Yellow()
        {
            using (ShimsContext.Create())
            {
                // System.Fakes.ShimDateTime.NowGet = () =>
                //{
                //	return new DateTime(2017, 1, 31); // This was a Tuesday
                //};

                string expected = "Yellow";
                var colors = new FavoriteColorGenerator();

                var result = colors.GetFavorite();

                Assert.AreEqual(expected, result);
            }
        }

        //    ***********************************
        //   *               POSE                *
        //   *  https://github.com/tonerdo/pose  *
        //   *                                   *
        //    ***********************************
        //   Pose is Open Source - uses runtime isolation.
        //   MS Fakes is Commerical and uses compile time Fakes
        //   Pose github not very active anymore (creator works at MS now)
        //   At least Fakes has official MS support. ¯\_(ツ)_/¯

        [TestMethod()]
        [Ignore]
        public void Pose_On_Tuesday_Should_Be_Yellow()
        {
            var dtShim = Pose.Shim.Replace(() => DateTime.Now)
                .With(() => new DateTime(2017, 1, 31));

            PoseContext.Isolate(() =>
            {
                string expected = "Yellow";
                var colors = new FavoriteColorGenerator();
                var result = colors.GetFavorite();

                Assert.AreEqual(expected, result);

            }, dtShim);
        }
    }
}