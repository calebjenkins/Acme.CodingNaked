using System;

namespace WithExtensionsLib.Extensions2
{
	public class BusinessToolExtensionsImp: IBusinessToolExtensions
	{
		public bool Reset(ISuperImportantBusinessTool bt, int Timing)
		{
			if (Timing.Random() % 2 == 0)
			{
				bt.Stop();
				bt.OtherReallyReallyImportantStuff(Timing);
				bt.Start();
				return true;
			}
			else
			{
				return false;
			}
		}
	}

	public interface IBusinessToolExtensions
	{
		bool Reset(ISuperImportantBusinessTool bt, int Timing);
	}

	public static class BusinessToolExtensions
	{
		public static IBusinessToolExtensions Implementation = new BusinessToolExtensionsImp();

		public static bool Reset(this ISuperImportantBusinessTool bt, int Timing)
		{
			return Implementation.Reset(bt, Timing);
		}



		// Extra Stuff //
		public static int Random(this int number)
		{
			if (number < 1)
				return 0;

			Random rnd = new Random(DateTime.Now.Second);
			var rndNum = rnd.Next(0, number);
			return rndNum;
		}
	}
}