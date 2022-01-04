using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlightlyHarderLib
{
	 public class FavoriteColorGenerator
	 {
		public string GetFavorite()
		{
			if(DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
			{
				return "Yellow";
			}
			else
			{
				return "Blue";
			}
		}
	}

	public class BusinessCounter
	{
		private int _counter;
		private ILogger _logger;

		public BusinessCounter(ILogger logger)
		{
			_logger = logger;
			_counter = 0;
		}

		public int CounterValue { get { return _counter; } }

		public void Count()
		{
			if (_counter++ % 3 == 0)
			{
				_logger.Info("Counter threshold reached");
			}
		}
	}

	public interface ILogger
	{
		void Log(LogType logType, string Message);
	}

	public enum LogType
	{
	Debug, 
	Info, 
	Error
	}

	public static class LogExtensions
	{
		public static void Debug(this ILogger logger, string Message)
		{
			logger.Log(LogType.Debug, Message);
		}
		public static void Info(this ILogger logger, string Message)
		{
			logger.Log(LogType.Info, Message);
		}
		public static void Error(this ILogger logger, string Message)
		{
			logger.Log(LogType.Error, Message);
		}
	}

	namespace myApp
	{
		public interface ILogger
		{
			void Debug(string Message);
			void Info(string Message);
			void Error(string Message);
		}
	}


	public class MyAppLogger : myApp.ILogger
	{
		ILogger _logger;
		public MyAppLogger(ILogger logger)
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
