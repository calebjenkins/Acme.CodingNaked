using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using WithExtensionsLib.Extensions;

namespace WithExtensionsLib
{
	public class BusinessProcessStart
	{
		private ISuperImportantBusinessTool bt;
		private int TimingFromConfig = 100;
		private ILogger _logger;

		public BusinessProcessStart(ISuperImportantBusinessTool bt, ILogger logger)
		{
			this.bt = bt;
			_logger = logger;
		}

		public void DoTheThing()
		{
			// So many things...


			// So much important//


			// OMGoodness .. this better happen properly!
			var result = bt.Reset(TimingFromConfig);

			// Many more important

			if(result)
			{
				//Continue with Process
			}
			else
			{
				// Log Failure
				_logger.LogError ("Reset Failed");
			}

		}
	}
}
