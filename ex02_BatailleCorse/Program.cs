using static ex02_BatailleCorse.Enums;

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

            //for (int i = 0; i < 16; i++)
            //{
            //    joueur1.Cartes.AjouterALaFin(Joueur.GetRandomCarte());
            //    joueur2.Cartes.AjouterALaFin(Joueur.GetRandomCarte());
            //    joueur3.Cartes.AjouterALaFin(Joueur.GetRandomCarte());
            //}

            //Jeu de test 1 : ok
            //joueur1.Cartes.AjouterALaFin(new Carte(Valeur.As, Couleur.Coeur));
            //joueur2.Cartes.AjouterALaFin(new Carte(Valeur.Huit, Couleur.Trefle));
            //joueur3.Cartes.AjouterALaFin(new Carte(Valeur.Roi, Couleur.Pique));
            //joueur1.Cartes.AjouterALaFin(new Carte(Valeur.As, Couleur.Pique));
            //joueur2.Cartes.AjouterALaFin(new Carte(Valeur.Sept, Couleur.Coeur));

            //Jeu de test 2 : ok
            joueur1.Cartes.AjouterALaFin(new Carte(Valeur.Roi, Couleur.Carreau));
            joueur2.Cartes.AjouterALaFin(new Carte(Valeur.Roi, Couleur.Carreau));
            joueur3.Cartes.AjouterALaFin(new Carte(Valeur.Sept, Couleur.Coeur));
            joueur3.Cartes.AjouterALaFin(new Carte(Valeur.Roi, Couleur.Trefle));
            joueur1.Cartes.AjouterALaFin(new Carte(Valeur.Neuf, Couleur.Trefle));
            joueur1.Cartes.AjouterALaFin(new Carte(Valeur.Sept, Couleur.Coeur));
            joueur2.Cartes.AjouterALaFin(new Carte(Valeur.Huit, Couleur.Coeur));
            joueur1.Cartes.AjouterALaFin(new Carte(Valeur.Sept, Couleur.Carreau));
            joueur3.Cartes.AjouterALaFin(new Carte(Valeur.Sept, Couleur.Trefle));

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
                        if(joueurs.nbElement > 0)
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
                    var nouveauDefis = j1.Defis(cartej1, joueurs, j1, j2, tas);
                    if (!nouveauDefis.HasValue)
                    {
                        Console.WriteLine(j2.Nom + " n'a plus de carte ! Elimination !");
                        if (joueurs.nbElement > 0)
                        {
                            j1 = j2;
                            j2 = joueurs.RetirerPremier();
                        }
                        else
                        {
                            Console.WriteLine(j1.Nom + " gagne !");
                            break;
                        }
                        continue;
                    }
                    else if (!nouveauDefis.Value)
                    {
                        joueurs.AjouterALaFin(j1);
                        j1 = joueurs.RetirerPremier();
                        joueurs.AjouterALaFin(j2);
                        j2 = joueurs.RetirerPremier();
                    }
                }
                else
                {
                    joueurs.AjouterALaFin(j1);
                    j1 = joueurs.RetirerPremier();
                    joueurs.AjouterALaFin(j2);
                    j2 = joueurs.RetirerPremier();
                }

                joueurs.AjouterALaFin(j1);
                j1 = joueurs.RetirerPremier();
                joueurs.AjouterALaFin(j2);
                j2 = joueurs.RetirerPremier();
            }
        }
    }
}
