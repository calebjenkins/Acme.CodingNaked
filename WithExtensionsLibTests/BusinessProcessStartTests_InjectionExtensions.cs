using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WithExtensionsLib.Extensions2;

namespace WithExtensionsLib.Tests
{
	[TestClass()]
	public class BusinessProcessStartTests_InjectionExtensions
	{
		// [TestMethod()]  // This will only pass sometimes..
		public void DoTheThing_should_Start_SetTiming_Stop_the_process()
		{
			// Arrange
			var btMock = new Mock<ISuperImportantBusinessTool>();
			btMock.Setup(m => m.Stop()).Verifiable();
			btMock.Setup(m => m.OtherReallyReallyImportantStuff(It.IsAny<int>())).Verifiable();
			btMock.Setup(m => m.Start()).Verifiable();

			var bt = btMock.Object;
			var sut = new BusinessProcessStart(bt);

			// Act
			sut.DoTheThing();

			// Assert
			btMock.Verify();
		}

		// [TestMethod()]
		public void DoTheThing_should_reset_the_process()
		{
			// Arrang
			var extMock = new Mock<IBusinessToolExtensions>();
			extMock.Setup(m => m.Reset(It.IsAny<ISuperImportantBusinessTool>(), It.IsAny<int>())).Returns(true).Verifiable();
			BusinessToolExtensions.Implementation = extMock.Object;

			ISuperImportantBusinessTool bt = new SuperImportantBusinessTool();
			var sut = new BusinessProcessStart(bt);

			// Act
			sut.DoTheThing();

			// Assert
			extMock.Verify();
		}

	}
}