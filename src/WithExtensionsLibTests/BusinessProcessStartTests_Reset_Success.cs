using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithExtensionsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.QualityTools.Testing.Fakes;
using Common.Logging;

namespace WithExtensionsLib.Tests
{
	[TestClass()]
	public class BusinessProcessStartTests_Reset_Success
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
		public void DoTheThing_should_Reset_the_Process()
		{
			// Arrange
			var btMock = new Mock<ISuperImportantBusinessTool>();
			// btMock.Setup(m => m.Reset(It.IsAny<int>())); // Oh crap. 
			var bt = btMock.Object;


			var sut = new BusinessProcessStart(bt, _logger);

			// Act
			sut.DoTheThing();

			// Assert
			btMock.Verify();

			// Assert.Ambiguous(); // not really a thing. 
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
			var sut = new BusinessProcessStart(bt, _logger);

			// Act
			sut.DoTheThing();

			// Assert
			btMock.Verify();
		}

		//[TestMethod()]
		public void DoTheThing_should_Reset_the_Process_with_MSFakes()
		{
			// Arrange
			var btMock = new Mock<ISuperImportantBusinessTool>();
			var bt = btMock.Object;
			var ResetWasCalled = false;

			using (ShimsContext.Create())
			{
				// Arrange:  
				Extensions.Fakes.ShimSuperImportantBusinessToolExtensions.ResetISuperImportantBusinessToolInt32 =
				(bps, b) => 
				{
					ResetWasCalled = true;
					 return true;
				};


				// Instantiate the component under test:  
				var sut = new BusinessProcessStart(bt, _logger);

				// Act:  
				sut.DoTheThing();
			}

			// Assert:   
			Assert.IsTrue(ResetWasCalled, "Reset Should have been called on the Super Important Business Tool");

			// Assert
			btMock.Verify();
		}

	}
}