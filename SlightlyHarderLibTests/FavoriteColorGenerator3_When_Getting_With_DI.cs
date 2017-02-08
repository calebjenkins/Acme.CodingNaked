using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SlightlyHarderLib.Tests
{
	[TestClass()]
	public class FavoriteColorGenerator3_When_Getting_With_DI
	{
		IDateTime dt;
		DateTime tuesday = new DateTime(2017, 1, 31);
		DateTime wednesday = new DateTime(2017, 2, 1);


		[TestInitialize]
		public void SetUp()
		{
			var dtMock = new Mock<IDateTime>();
			dtMock.Setup(m => m.Now).Returns(tuesday);
			dt = dtMock.Object;
		}


		[TestMethod()]
		public void On_Tuesday_Should_Be_Yellow()
		{
			string expected = "Yellow";
			var colors = new FavoriteColorGeneratorWithDI(dt);

			var result = colors.GetFavorite();

			Assert.AreEqual(expected, result);
		}


		[TestMethod]
		public void On_Wed_Should_Be_Blue()
		{
			var dtMock = new Mock<IDateTime>();
			dtMock.Setup(m => m.Now).Returns(wednesday);
			dt = dtMock.Object;

			string expected = "Blue";
			var colors = new FavoriteColorGeneratorWithDI(dt);

			var result = colors.GetFavorite();

			Assert.AreEqual(expected, result);
			dtMock.Verify();
		}
	}
}