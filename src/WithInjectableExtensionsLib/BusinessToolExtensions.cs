using System;

namespace WithExtensionsLib.Extensions
{
	public static class BusinessToolExtensions
	{
		public static bool Reset(this ISuperImportantBusinessTool bt, int Timing)
		{

			// We do nothing with Timing
			try
			{
				bt.Stop();
				bt.OtherReallyReallyImportantStuff(Timing);
				bt.Start();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}