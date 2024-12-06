namespace ex02_BatailleCorse
{
    public class Partie
    {
        private Anneau<Joueur> joueurs;
        private Anneau<Carte> tas;
        private Joueur? j1;
        private Joueur? j2;
        private bool tourSuivant = false;

        public Partie(ref Anneau<Joueur> joueurs, ref Anneau<Carte> tas, ref Joueur? j1, ref Joueur? j2) 
        {
            this.joueurs = joueurs;
            this.tas = tas;
            this.j1 = j1;
            this.j2 = j2;
        }

        public bool DebutDuTour(bool stop)
        {
            if (tas.Element == null || !tas.LireDernier().IsTete())
            {
                var cartej1 = j1.JouerUneCarte(tas);
                if (cartej1 == null)
                {
                    Console.WriteLine(j1.Nom + " n'a plus de cartes ! Elimination !");
                    if (joueurs.nbElement > 0)
                    {
                        j1 = j2;
                        j2 = joueurs.RetirerPremier();
                    }
                    else
                    {
                        Console.WriteLine(j2.Nom + " gagne !");
                        stop = true;
                    }
                    tourSuivant = true;
                }
            }

            return stop;
        }

        public bool Defi(bool stop)
        {
            if (!stop && !tourSuivant)
            {
                if (tas.Element != null && tas.LireDernier().IsTete())
                {
                    var nouveauDefi = j1.Defi(j2, joueurs, tas);
                    if (!nouveauDefi.HasValue)
                    {
                        Console.WriteLine(j2.Nom + " n'a plus de carte ! Elimination !");
                        if (joueurs.nbElement > 0)
                        {
                            j2 = joueurs.RetirerPremier();
                            if (tas.LireDernier().IsTete()) joueurs.Suivant(ref j1, ref j2);
                        }
                        else
                        {
                            Console.WriteLine(j1.Nom + " gagne !");
                            if (joueurs.nbElement == 0) stop = true;
                        }
                    }
                    else if (nouveauDefi.Value)
                    {
                        if (joueurs.nbElement > 0) joueurs.Suivant(ref j1, ref j2);
                    }
                    else
                    {
                        if (joueurs.nbElement == 0) joueurs.Suivant(ref j1, ref j2);
                    }
                }
                else
                {
                    if (joueurs.nbElement > 0) joueurs.Suivant(ref j1, ref j2);
                }
            }

            return  stop;
        }

        public void FinDeTour(bool stop)
        {
            if (!stop && !tourSuivant)
            {
                joueurs.Suivant(ref j1, ref j2);
            }
        }
    }
}
