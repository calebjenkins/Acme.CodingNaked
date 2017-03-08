using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithExtensionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace WithExtensionsLib.Tests
{
	[TestClass()]
	public class BusinessProcessStartTests
	{
		[TestMethod()]
		public void DoTheThing_should_Reset_the_Process()
		{
			// Arrange
			var btMock = new Mock<ISuperImportantBusinessTool>();
			var bt = btMock.Object;
			var sut = new BusinessProcessStart(bt);

			// Act
			sut.DoTheThing();

			// Assert
			btMock.Verify();
		}

		[TestMethod()]
		public void DoTheThing_should_Stop_SetTiming_Start_the_process()
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
	}
}