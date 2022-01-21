using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlightlyHarderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlightlyHarderLib.Tests
{
	[TestClass()]
	public class FavoriteColorGenerator_When_Getting_
	{
		// One of these will always fail
		[TestMethod()]
		[Ignore]
		public void On_Tuesday_Should_Be_Yellow()
		{
			string expected = "Yellow";
			var colors = new FavoriteColorGenerator();

			var result = colors.GetFavorite();

			Assert.AreEqual(expected, result);
		}


		[TestMethod]
		[Ignore]
		public void On_Wed_Should_Be_Blue()
		{
			string expected = "Blue";
			var colors = new FavoriteColorGenerator();

			var result = colors.GetFavorite();

			Assert.AreEqual(expected, result);
		}
	}
}