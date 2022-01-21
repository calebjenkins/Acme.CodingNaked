using System;
using System.Linq;

namespace SlightlyHarderLib
{
	public class AcmeDateTime: IDateTime
	{
		public DateTime Now
		{
			get { return DateTime.Now; }
		}
	}
}
