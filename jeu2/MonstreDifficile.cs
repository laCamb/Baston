using System;
using System.Collections.Generic;
using System.Text;

namespace jeu2
{
	public class MonstreDifficile : MonstreFacile
	{
		private const int degatsSort = 5;
		private int ExperienceGived = 3;

		public override void Attaque(Joueur joueur)
		{
			base.Attaque(joueur);
			joueur.SubitDegats(SortMagique());
		}

		private int SortMagique()
		{
			int valeur = de.LanceLeDe();
			if (valeur == 6)
				return 0;
			return degatsSort * valeur;
		}
		public override int GetExperience()
        {
			return ExperienceGived;
        }


	}
}
