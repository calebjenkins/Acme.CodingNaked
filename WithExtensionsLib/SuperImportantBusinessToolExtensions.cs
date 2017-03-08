using System;

namespace WithExtensionsLib.Extensions
{
	public static class SuperImportantBusinessToolExtensions
	{
		public static bool Reset(this ISuperImportantBusinessTool bt, int Timing)
		{
		
			// We do nothing with Timing

				bt.Stop();
				bt.OtherReallyReallyImportantStuff(Timing);
				bt.Start();
				return true;
		}
	}
}