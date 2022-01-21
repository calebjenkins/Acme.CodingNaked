using System;

namespace WithExtensionsLib.Extensions2
{
    public static class MathExtension
    {
		public static int Random(this int number)
		{
			if (number < 1)
				return 0;

			Random rnd = new Random(DateTime.Now.Second);
			var rndNum = rnd.Next(0, number);
			return rndNum;
		}

	}
}