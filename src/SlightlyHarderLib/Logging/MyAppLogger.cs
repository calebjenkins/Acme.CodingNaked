namespace SlightlyHarderLib
{
         public class MyAppLogger : IAppLogger
		{
			IEnterpriseLogger _logger;
			public MyAppLogger(IEnterpriseLogger logger)
			{
				_logger = logger;
			}

			public void Debug(string Message)
			{
				_logger.Debug(Message);
			}

			public void Error(string Message)
			{
				_logger.Error(Message);
			}

			public void Info(string Message)
			{
				_logger.Info(Message);
			}
		}
	}
