using System;
using System.Collections.Generic;
using System.Text;

namespace jeu2
{
	public class MonstreFacile
	{
		private int ExperienceGived;
		private const int degats = 10;
		protected De de;
		public bool EstVivant { get; private set; }

		public MonstreFacile()
		{
			ExperienceGived = 2;
			de = new De();
			EstVivant = true;
		}

		public virtual void Attaque(Joueur joueur)
		{
			int lanceMonstre = LanceLeDe();
			int lanceJoueur = joueur.LanceLeDe();
			if (lanceMonstre > lanceJoueur)
				joueur.SubitDegats(degats);
		}

		public void SubitDegats()
		{
			EstVivant = false;
		}

		public int LanceLeDe()
		{
			return de.LanceLeDe();
		}
		public virtual int GetExperience()
        {
			return ExperienceGived;
        }
	}
}
