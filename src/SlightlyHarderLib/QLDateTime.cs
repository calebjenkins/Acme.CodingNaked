using System;
using System.Linq;

namespace SlightlyHarderLib
{
	public class QLDateTime: IDateTime
	{
		public DateTime Now
		{
			get { return DateTime.Now; }
		}
	}
}
