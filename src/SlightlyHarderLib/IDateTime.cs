using System;
using System.Linq;

namespace SlightlyHarderLib
{
	public interface IDateTime
	{
		DateTime Now { get; }
	}

	public class AcemDateTime : IDateTime
	{
		public DateTime Now
		{
			get { return DateTime.Now; }
		}
	}
}
