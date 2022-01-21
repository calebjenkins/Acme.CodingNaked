using System;
using System.Linq;
using Pose;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SlightlyHarderLib.Tests
{
    [TestClass()]
    public class FavoriteColorGenerator2_When_Getting_with_Pose_
    {

        ////	/****************************************
        ////	 *										*
        ////	 *            DONT USE FAKES			*
        ////	 *										*
        ////	 * *************************************/

        [TestMethod()]
        public void On_Tuesday_Should_Be_Yellow()
        {
            var tues = new DateTime(2017, 1, 24);
            var dtShim = Shim.Replace(() => DateTime.Now)
                .With(() => tues);  // This was a Tuesday

            string expected = "Yellow";
            string result = "";

            PoseContext.Isolate(() =>
            {
                var colors = new FavoriteColorGenerator();
                result = colors.GetFavorite();

            }, dtShim);

            Assert.AreEqual(expected, result);

        }


        //		// [TestMethod]
        //		public void On_Wed_Should_Be_Blue()
        //		{
        //			string expected = "Blue";
        //			var colors = new FavoriteColorGenerator();

        //			var result = colors.GetFavorite();

        //			Assert.AreEqual(expected, result);
        //		}
    }
}