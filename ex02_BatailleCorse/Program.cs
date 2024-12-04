using static ex02_BatailleCorse.Enums;

namespace ex02_BatailleCorse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var Joueurs = new Anneau<Joueur>();
            var joueur1 = new Joueur("Maxime");
            var joueur2 = new Joueur("Lucie");
            var tas = new Anneau<Carte>();

            joueur1.Cartes.AjouterALaFin(new Carte(Valeur.As, Couleur.Trefle));
            joueur1.Cartes.AjouterALaFin(new Carte(Valeur.Dame, Couleur.Trefle));
            joueur1.Cartes.AjouterALaFin(new Carte(Valeur.Neuf, Couleur.Trefle));
            joueur1.Cartes.AjouterALaFin(new Carte(Valeur.Sept, Couleur.Trefle));

            joueur2.Cartes.AjouterALaFin(new Carte(Valeur.Huit, Couleur.Trefle));
            joueur2.Cartes.AjouterALaFin(new Carte(Valeur.Valet, Couleur.Trefle));
            joueur2.Cartes.AjouterALaFin(new Carte(Valeur.Dame, Couleur.Trefle));
            joueur2.Cartes.AjouterALaFin(new Carte(Valeur.Sept, Couleur.Trefle));

            for (int i = 0; i < 5; i++)
            {
                var cartej1 = joueur1.JouerUneCarte(tas);
                if (cartej1 == null) break;

                if (cartej1.GetTete())
                {
                    var defisGagne = joueur1.Defis(cartej1, joueur2, tas);
                    if (defisGagne)
                    {
                        //j2 doit jouer
                        var joueurTmp = joueur1;
                        joueur1 = joueur2;
                        joueur2 = joueurTmp;
                    }
                    else
                    {
                        //j1 doit rejouer
                    }
                }
            }

            if (joueur1.Cartes.Element == null) Console.WriteLine(joueur2.Nom + " gagne ! Il a " + joueur2.Cartes.nbElement + " cartes");
            if (joueur2.Cartes.Element == null) Console.WriteLine(joueur1.Nom + " gagne ! Il a " + joueur1.Cartes.nbElement + " cartes");

            //var jeuDeCarte = new Carte();
            //for (int i = 0; i < 4; i++)
            //{
            //    joueur1.AjouterALaFin(new Maillon<Carte>(jeuDeCarte.GetRandomCarte()));
            //    joueur2.AjouterALaFin(new Maillon<Carte>(jeuDeCarte.GetRandomCarte()));
            //}

            //Maillon<Carte>? cartej1;
            //Maillon<Carte>? cartej2;

            ////while (cartej1 != null && cartej2 != null)
            //while (true)
            //{
            //    cartej1 = JouerUneCarte(joueur1, tas);
            //    if (cartej1 == null) { break; }

            //    for (int i = 0; i < GetNombreDeTentatives(cartej1); i++)
            //    {
            //        cartej2 = JouerUneCarte(joueur2, tas);
            //        if (cartej2 == null) { break; }

            //        if (!GetTete(cartej2))
            //        {
            //            if(i == GetNombreDeTentatives(cartej1) - 1)
            //            {
            //                Console.WriteLine("Le défi est perdu ! joue un " + joueur1.nom + " remporte " + tas.nbElement + " cartes !");
            //                joueur1.AjouterAnneauLaFin(tas);
            //                tas.Element = null;
            //                tas.nbElement = 0;
            //                break;
            //            }
            //        }
            //        else
            //        {

            //            break;
            //            //cartej2 = JouerUneCarte(joueur2, tas);
            //            //if (cartej2 == null) { break; }
            //        }
            //    }

            //    cartej2 = JouerUneCarte(joueur2, tas);
            //    if (cartej2 == null) { break; }

            //    for (int i = 0; i < GetNombreDeTentatives(cartej2); i++)
            //    {
            //        cartej1 = JouerUneCarte(joueur1, tas);
            //        if (cartej1 == null) { break; }

            //        if (!GetTete(cartej1))
            //        {
            //            if (i == GetNombreDeTentatives(cartej2) - 1)
            //            {
            //                Console.WriteLine("Le défi est perdu ! joue un " + joueur2.nom + " remporte " + tas.nbElement + " cartes !");
            //                joueur2.AjouterAnneauLaFin(tas);
            //                tas.Element = null;
            //                tas.nbElement = 0;
            //                break;
            //            }
            //        }
            //        else
            //        {
            //            break;
            //            //cartej1 = JouerUneCarte(joueur1, tas);
            //            //if (cartej1 == null) { break; }
            //        }
            //    }
            //}

            //if (joueur1.Element == null) Console.WriteLine(joueur2.nom + " gagne !");
            //if (joueur2.Element == null) Console.WriteLine(joueur1.nom + " gagne !");
        }
    }
}
