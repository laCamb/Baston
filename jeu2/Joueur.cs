using System;
using System.Collections.Generic;
using System.Text;

namespace jeu2
{
	public class Joueur
	{
		private De de;
		public int PtsDeVies { get; private set; }
		public bool EstVivant { get { return PtsDeVies > 0; }}
		int DegatsSup { get { return Niveau-1; } }
		public int Niveau { get; set; }
		public double Experience { get; private set; }
		public Joueur(int points)
		{
			Niveau = 1;
			Experience = 0;
			PtsDeVies = points;
			de = new De();
		}

		public void Attaque(MonstreFacile monstre)
		{
			int lanceJoueur = LanceLeDe();
			int lanceMonstre = monstre.LanceLeDe();
			if (lanceJoueur >= lanceMonstre)
			{
				monstre.SubitDegats();
				Experience += monstre.GetExperience();
				if (Experience > 5 * Niveau)
					NiveauSuperieur();
			}
		}
		public void Attaque(Boss boss)
		{
			int lanceJoueur = LanceLeDe(25);
			boss.SubitDegats(lanceJoueur + DegatsSup);
		}

		public int LanceLeDe(int MaximunScore = 6)
		{
			return de.LanceLeDe(MaximunScore + 1);
		}

		public void SubitDegats(int degats)
		{
			if (!BouclierFonctionne())
				PtsDeVies -= degats;
		}

		private bool BouclierFonctionne()
		{
			return de.LanceLeDe() <= 2;
		}
		private void NiveauSuperieur()
		{
			Niveau++;
			Console.WriteLine("- -- -- - Niveau Superieur - -- -- -  Niv. {0}", Niveau);
		}
	}
}
