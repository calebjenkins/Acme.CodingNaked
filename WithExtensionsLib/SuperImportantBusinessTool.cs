using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithExtensionsLib
{
	public class SuperImportantBusinessTool: ISuperImportantBusinessTool
	{
		bool _running;
		public void Start()
		{
			_running = true;
		}
		public void Stop()
		{
			_running = false;
		}

		public void OtherReallyReallyImportantStuff(int Timing)
		{
			var x = Timing; // we're not really doing anything here. 
		}

		#region "Hiding at start - Peak strategy"

		//public bool Running
		//{
		//	get { return _running; }
		//}

		#endregion
	}
}
