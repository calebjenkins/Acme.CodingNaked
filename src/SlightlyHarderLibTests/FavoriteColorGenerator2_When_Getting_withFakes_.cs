//using System;
//using System.Linq;
//using Microsoft.QualityTools.Testing.Fakes;
//using Microsoft.VisualStudio.TestTools.UnitTesting;


//namespace SlightlyHarderLib.Tests
//{
//	public class FavoriteColorGenerator2_When_Getting_withFakes_
//	{

//	/****************************************
//	 *										*
//	 *            DONT USE FAKES			*
//	 *										*
//	 * *************************************/

//		// [TestMethod()]
//		public void On_Tuesday_Should_Be_Yellow()
//		{
//			using (ShimsContext.Create())
//			{
//				//System.Fakes.ShimDateTime.NowGet = () =>
//				//{
//				//	return new DateTime(2017, 1, 31); // This was a Tuesday
//				//};

//				string expected = "Yellow";
//				var colors = new FavoriteColorGenerator();

//				var result = colors.GetFavorite();

//				Assert.AreEqual(expected, result);

//			}
//		}


//		// [TestMethod]
//		public void On_Wed_Should_Be_Blue()
//		{
//			string expected = "Blue";
//			var colors = new FavoriteColorGenerator();

//			var result = colors.GetFavorite();

//			Assert.AreEqual(expected, result);
//		}
//	}
//}