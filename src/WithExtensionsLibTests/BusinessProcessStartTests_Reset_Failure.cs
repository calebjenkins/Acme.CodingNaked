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
            loggerMock.VerifyLogging(expecteLogText, LogLevel.Error, Times.Once());

        }
    }

    public static class MoqLoggingExtensions
    {
        // Hat Tip Adam Storr
        // Awesome Extension Method for Verifying via https://adamstorr.azurewebsites.net/blog/mocking-ilogger-with-moq
        // https://github.com/WestDiscGolf/Random
        public static Mock<ILogger> VerifyLogging(this Mock<ILogger> logger, string expectedMessage, LogLevel expectedLogLevel = LogLevel.Debug, Times? times = null)
        {
            times ??= Times.Once();

            Func<object, Type, bool> state = (v, t) => v.ToString().CompareTo(expectedMessage) == 0;

            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == expectedLogLevel),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), (Times)times);

            return logger;
        }
        public static Mock<ILogger<T>> VerifyLogging<T>(this Mock<ILogger<T>> logger, string expectedMessage, LogLevel expectedLogLevel = LogLevel.Debug, Times? times = null)
        {
            times ??= Times.Once();

            Func<object, Type, bool> state = (v, t) => v.ToString().CompareTo(expectedMessage) == 0;

            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == expectedLogLevel),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), (Times)times);

            return logger;
        }
    }
}