namespace WithExtensionsLib.Extensions2
{
    public class BusinessToolExtensionsImp: IBusinessToolExtensions
	{
		public bool Reset(ISuperImportantBusinessTool bt)
		{
			try
			{
				bt.Stop();
				bt.OtherReallyReallyImportantStuff(15);
				bt.Start();	
				return true;
			}
			catch
			{
				return false;
			}
		}
	}

	public interface IBusinessToolExtensions
	{
		bool Reset(ISuperImportantBusinessTool bt);
	}


	public static class BusinessToolExtensions
	{
		public static IBusinessToolExtensions Implementation = new BusinessToolExtensionsImp();

		public static bool Reset(this ISuperImportantBusinessTool bt)
		{
			return Implementation.Reset(bt);
		}
	}
}