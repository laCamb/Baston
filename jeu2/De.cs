using System;
using System.Collections.Generic;
using System.Text;

namespace jeu2
{
	public class De
	{
		private Random random;

		public De()
		{
			random = new Random();
		}
		public int LanceLeDe(int MaximunScore = 6)
		{
			return random.Next(1, MaximunScore+1);
		}
	}
}
