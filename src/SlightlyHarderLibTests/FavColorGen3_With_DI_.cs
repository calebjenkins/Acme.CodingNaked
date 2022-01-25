using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SlightlyHarderLib.Tests
{
	[TestClass()]
	public class FavColorGen3_With_DI_
	{
		IDateTime dt;
		DateTime tuesday;
		DateTime wednesday;


		[TestInitialize]
		public void SetUp()
		{
			tuesday = new DateTime(2017, 1, 31);
			wednesday = new DateTime(2017, 2, 1);
		}


		[TestMethod()]
		public void On_Tuesday_Should_Be_Yellow()
		{
			var dtMock = new Mock<IDateTime>();
			dtMock.Setup(m => m.Now).Returns(tuesday);
			dt = dtMock.Object;

			string expected = "Yellow";
			var colors = new FavoriteColorGeneratorWithDI(dt);

			var result = colors.GetFavorite();

			Assert.AreEqual(expected, result);
		}


		[TestMethod]
		public void On_Wed_Should_Be_Blue()
		{
			var dtMock = new Mock<IDateTime>();
			dtMock.Setup(m => m.Now).Returns(wednesday).Verifiable();
			dt = dtMock.Object;

			string expected = "Blue";
			var colors = new FavoriteColorGeneratorWithDI(dt);

			var result = colors.GetFavorite();

			Assert.AreEqual(expected, result);
			dtMock.Verify();
		}
	}
}