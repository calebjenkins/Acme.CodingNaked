namespace SlightlyHarderLib
{
    public static class EnterpriseLogExtensions
	{
		public static void Debug(this IEnterpriseLogger logger, string Message)
		{
			logger.Log(LogType.Debug, Message);
		}
		public static void Info(this IEnterpriseLogger logger, string Message)
		{
			logger.Log(LogType.Info, Message);
		}
		public static void Error(this IEnterpriseLogger logger, string Message)
		{
			logger.Log(LogType.Error, Message);
		}
	}
}
