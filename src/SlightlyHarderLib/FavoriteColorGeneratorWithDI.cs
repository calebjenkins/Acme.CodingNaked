using System;
using System.Linq;

namespace SlightlyHarderLib
{
	public class FavoriteColorGeneratorWithDI
	{
		IDateTime dt;

		public FavoriteColorGeneratorWithDI(IDateTime dt)
		{
			this.dt = dt;
		}

		// Poorman's DI
        public FavoriteColorGeneratorWithDI() : this (new AcmeDateTime()) {  }

		public string GetFavorite()
		{
			if (dt.Now.DayOfWeek == DayOfWeek.Tuesday)
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
