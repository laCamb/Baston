using System;

namespace jeu2
{
	class Program
	{
		private static Random random = new Random();

		static void Main(string[] args)
		{
			Console.WriteLine("Que voulez vous: \n\a\a A- Combattre des Montres\n\a\a B- Tenter le BOSS !!!");
			var input = Console.ReadKey(true);
			switch (input.Key)
			{
				case ConsoleKey.A:
					Jeu1();
					break;
				case ConsoleKey.B:
					Jeu2();
					break;
				default:
					Console.WriteLine("decidez vous grand Dieu!!");
					break;

			}
		}

		private static void Jeu1()
		{
			Joueur nicolas = new Joueur(150);
			int cptFacile = 0;
			int cptDifficile = 0;
			while (nicolas.EstVivant)
			{
				MonstreFacile monstre = FabriqueDeMonstre();
				while (monstre.EstVivant && nicolas.EstVivant)
				{
					nicolas.Attaque(monstre);
					if (monstre.EstVivant)
						monstre.Attaque(nicolas);
				}

				if (nicolas.EstVivant)
				{
					if (monstre is MonstreDifficile)
						cptDifficile++;
					else
						cptFacile++;
				}
				else
				{
					Console.WriteLine("Snif, vous êtes mort...");
					break;
				}
			}
			Console.WriteLine("Vous avez tué {0} monstres faciles et {1} monstres difficiles. " +
				"Vous êtes mort au niveau {3} avec {2} points.", cptFacile, cptDifficile, cptFacile + cptDifficile * 2, nicolas.Niveau);
			Console.WriteLine("Que voulez vous: \n\a\a A- Rester mort a terre\n\a\a B- Tenter le BOSS !!!");
			var input = Console.ReadKey(true);
			switch (input.Key)
			{
				case ConsoleKey.A:
					Console.WriteLine("Vous etes morts et bien mort ducoup, reposez vous");
					break;
				case ConsoleKey.B:
					Jeu2(nicolas.Niveau);
					break;
				default:
					Console.WriteLine("trop tard pour ce decider grand Dieu!!");
					break;

			}
		}
		private static void Jeu2(int niveau = 0)
		{

			Joueur nicolas = new Joueur(50) { Niveau = niveau };
			Boss bigBoss = new Boss(250);
			while (nicolas.EstVivant && bigBoss.EstVivant)
			{

				nicolas.Attaque(bigBoss);
				if (bigBoss.EstVivant)
					bigBoss.Attaque(nicolas);
				else
				{
					Console.WriteLine("Vous avez defait le Boss " +
						"et il vous reste {0} pts de vies", nicolas.PtsDeVies);
					break;
				}
			}
			if (!nicolas.EstVivant)
				Console.WriteLine("Vous etes mort et bien mort, " +
					"il restait {0} pts de vies au Boss", bigBoss.PtsDeVies);
		}

		private static MonstreFacile FabriqueDeMonstre()
		{
			if (random.Next(2) == 0)
				return new MonstreFacile();
			else
				return new MonstreDifficile();
		}
	}
}
