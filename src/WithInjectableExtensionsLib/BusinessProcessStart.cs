using System;
using System.Linq;
using WithExtensionsLib.Extensions;

namespace WithExtensionsLib
{
	public class BusinessProcessStart
	{
		private ISuperImportantBusinessTool bt;
		private int TimingFromConfig = 100;

		public BusinessProcessStart(ISuperImportantBusinessTool bt)
		{
			this.bt = bt;
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
			}

		}
	}
}
