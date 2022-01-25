using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlightlyHarderLib
{
    public partial class FavoriteColorGenerator
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
}
