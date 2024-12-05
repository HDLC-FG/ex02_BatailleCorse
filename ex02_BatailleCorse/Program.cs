namespace ex02_BatailleCorse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var joueur1 = new Joueur("J1 - Julie");
            var joueur2 = new Joueur("J2 - Maxime");
            var joueur3 = new Joueur("J3 - Mélanie");
            var tas = new Anneau<Carte>();

            for (int i = 0; i < 8; i++)
            {
                joueur1.Cartes.AjouterALaFin(Joueur.GetRandomCarte());
                joueur2.Cartes.AjouterALaFin(Joueur.GetRandomCarte());
                joueur3.Cartes.AjouterALaFin(Joueur.GetRandomCarte());
            }

            var joueurs = new Anneau<Joueur>();
            joueurs.AjouterALaFin(joueur1);
            joueurs.AjouterALaFin(joueur2);
            joueurs.AjouterALaFin(joueur3);

            Carte? cartej1 = new Carte();
            Joueur? j1 = joueurs.RetirerPremier();
            Joueur? j2 = joueurs.RetirerPremier();

            while (true)
            {
                if (tas.Element == null || !tas.LireDernier().IsTete())
                {
                    cartej1 = j1.JouerUneCarte(tas);
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
                            break;
                        }
                        continue;
                    }
                }

                if (tas.Element != null && tas.LireDernier().IsTete())
                {
                    var nouveauDefi = j1.Defi(joueurs, j2, tas);
                    if (!nouveauDefi.HasValue)
                    {
                        Console.WriteLine(j2.Nom + " n'a plus de carte ! Elimination !");
                        if (joueurs.nbElement > 0)
                        {
                            j2 = joueurs.RetirerPremier();
                            if (tas.LireDernier().IsTete()) Joueur.Suivant(joueurs, ref j1, ref j2);
                        }
                        else
                        {
                            Console.WriteLine(j1.Nom + " gagne !");
                            if (joueurs.nbElement == 0) break;
                        }
                    }
                    else if (nouveauDefi.Value)
                    {
                        if (joueurs.nbElement > 0) Joueur.Suivant(joueurs, ref j1, ref j2);
                    }
                    else
                    {
                        if (joueurs.nbElement == 0) Joueur.Suivant(joueurs, ref j1, ref j2);
                    }
                }
                else
                {
                    if (joueurs.nbElement > 0) Joueur.Suivant(joueurs, ref j1, ref j2);
                }

                Joueur.Suivant(joueurs, ref j1, ref j2);
            }
        }
    }
}
