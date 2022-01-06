using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;



namespace SimpleCalculationsLib.Tests
{
    [TestClass()]
    public class EasiestToTestMethodsEvar2_when_adding_should
    {
         /*******************************
		 *					        	*
		 *   Using FluentAssertions		*
		 *						        *
		 *******************************/

        [TestMethod()]
        public void Should_combine_two_numbers_to_4()
        {
            int expected = 4;
            var sut = new EasiestToTestMethodsEvar();
            var result = sut.Add(2, 2);

            result.Should<int>().Be(expected);
            //--------//
        }

        [TestMethod()]
        public void Should_combine_two_numbers_Different_Numbers()
        {
            int expected = 7;
            var sut = new EasiestToTestMethodsEvar();
            var result = sut.Add(3, 4);

            result.Should<int>().BeGreaterThan(4);
            result.Should<int>().BeLessThanOrEqualTo(10);

            result.Should<int>().Be(expected);
        }

    }
}