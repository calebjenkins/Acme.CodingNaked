using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithExtensionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WithExtensionsLib.Extensions2;
using Moq;

namespace WithExtensionsLib.Tests
{
	[TestClass()]
	public class BusinessProcessStartTests
	{
		[TestMethod()]
		public void DoTheThingTest()
		{
			ISuperImportantBusinessTool sut = new SuperImportantBusinessTool();

			var ext = new Mock<IBusinessToolExtensions>();
			ext.Setup(x => x.Reset(sut)).Returns(false).Verifiable();
			BusinessToolExtensions.Implementation = ext.Object;

			Assert.IsFalse( sut.Reset() );
			// demonstrating Injectable Extension Method, not an actual unit test

			BusinessToolExtensions.Implementation = new BusinessToolExtensionsImp();
		}
	}
}