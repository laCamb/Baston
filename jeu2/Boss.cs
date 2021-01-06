using System;
using System.Collections.Generic;
using System.Text;

namespace jeu2
{
    public class Boss
    {
        public int PtsDeVies;
        private De de;
        public bool EstVivant
        {
            get { return PtsDeVies > 0; }
        }

        public Boss(int ptsDeVie)
        {
            de = new De();
            PtsDeVies = ptsDeVie;
        }
        public int LanceLeDe()
        {
            return de.LanceLeDe(25);
        }
        public void Attaque(Joueur joueur)
        {
            int lanceBoss = LanceLeDe();
            joueur.SubitDegats(lanceBoss);
        }
        public void SubitDegats(int degats)
        {
            PtsDeVies -= degats;
        }
    }
}
