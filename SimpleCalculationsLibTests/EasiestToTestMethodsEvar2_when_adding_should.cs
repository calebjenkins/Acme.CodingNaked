using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace SimpleCalculationsLib.Tests
{
	[TestClass()]
	public class EasiestToTestMethodsEvar2_when_adding_should
	{
		/************************
		 *						*
		 *   Using Should		*
		 *						*
		 ************************/

		[TestMethod()]
		public void Should_combine_two_numbers_to_4()
		{
			int expected = 4;
			var sut = new EasiestToTestMethodsEvar();
			var result = sut.Add(2, 2);

			result.ShouldEqual<int>(expected);
				  //--------//
		}

		[TestMethod()]
		public void Should_combine_two_numbers_Different_Numbers()
		{
			int expected = 7;
			var sut = new EasiestToTestMethodsEvar();
			var result = sut.Add(3, 4);

			result.ShouldBeGreaterThan<int>(4);
			result.ShouldBeLessThanOrEqualTo<int>(10);

			result.ShouldEqual<int>(result);
		}

	}
}