using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculationsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculationsLib.Tests
{
	[TestClass()]
	public class EasiestToTestMethodsEvar_when_adding
	{
		[TestMethod()]
		public void Should_combine_two_numbers_to_4()
		{
			int expected = 4;
			var sut = new EasiestToTestMethodsEvar();
			var result = sut.Add(2, 2);

			Assert.AreEqual(expected, result);
		}

		[TestMethod()]
		public void Should_combine_two_numbers_Different_Numbers()
		{
			int expected = 7;
			var sut = new EasiestToTestMethodsEvar();
			var result = sut.Add(3, 4);

			Assert.AreEqual(expected, result);
		}

	}
}