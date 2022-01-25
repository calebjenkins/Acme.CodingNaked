using System;
using System.Linq;

namespace SlightlyHarderLib
{
	public class FavoriteColorGeneratorWithDI
	{
		IDateTime dt;

		// Poor Man's DI
		public FavoriteColorGeneratorWithDI() : this(new AcemDateTime()) { }

		// We pass this in for testability.. 
		public FavoriteColorGeneratorWithDI(IDateTime dt)
		{
			this.dt = dt;
		}
		public string GetFavorite()
		{
			return (dt.Now.DayOfWeek == DayOfWeek.Tuesday) ?
				"Yellow" : "Blue";
		}
	}
}
