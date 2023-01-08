using System;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WithExtensionsLib.Tests
{
    [TestClass()]
    public class BusinessProcessStartTests_Reset_Failure
    {
        ILogger _logger;
        ISuperImportantBusinessTool _businessTool;

        [TestInitialize]
        public void SetUp()
        {
            _logger = new Mock<ILogger>().Object;
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
            // var loggerMock = new Mock<ILogger>();
            // What I want to mock (extension)	    ===> LogError (expecteLogText));
            // The public Interface has one method	===> Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter);
            // Everything else is an extention method. ¯\_(ツ)_/¯
            // Awesome Extension Method for Verifying via https://adamstorr.azurewebsites.net/blog/mocking-ilogger-with-moq

            var loggerMock = new Mock<ILogger>();
            _logger = loggerMock.Object;


            var sut = new BusinessProcessStart(bt, _logger);

            // Act
            sut.DoTheThing();

            // Assert
            btMock.Verify();
            loggerMock.VerifyLogging("Reset Failed", LogLevel.Error, Times.Once());

        }
    }
}