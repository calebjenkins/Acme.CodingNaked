using System;
using System.Linq;
using Common.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WithExtensionsLib.Tests
{
	[TestClass()]
	public class BusinessProcessStartTests_Reset_Failure
	{
		ILog _logger;
		ISuperImportantBusinessTool _businessTool;

		[TestInitialize]
		public void SetUp()
		{
			_logger = new Mock<ILog>().Object;
			_businessTool = new SuperImportantBusinessTool();
		}


		[TestMethod()]
		public void DoTheThing_Reset_Failure_Should_be_Logged()
		{
			// Arrange
			var btMock = new Mock<ISuperImportantBusinessTool>();
			btMock.Setup(m => m.Stop())
				.Throws(new Exception("doh!"))
				.Verifiable();
			var bt = btMock.Object;

			var expecteLogText = "Reset Failed";
			var loggerMock = new Mock<ILog>();
			loggerMock.Setup(m => m.Info(expecteLogText));
			_logger = loggerMock.Object;

			var sut = new BusinessProcessStart(bt, _logger);

			// Act
			sut.DoTheThing();

			// Assert
			btMock.Verify();
			loggerMock.Verify(m => m.Info(expecteLogText), Times.AtLeastOnce());
		}

	}
}