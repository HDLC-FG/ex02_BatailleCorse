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

            for (int i = 0; i < 12; i++)
            {
                joueur1.Cartes.AjouterALaFin(Joueur.GetRandomCarte());
                joueur2.Cartes.AjouterALaFin(Joueur.GetRandomCarte());
            }

            Carte? cartej1;
            for (int i = 0; i < 30; i++)
            //while (true)
            {
                cartej1 = joueur1.JouerUneCarte(tas);
                if (cartej1 == null)
                {
                    Console.WriteLine(joueur1.Nom + " n'a plus de carte ! Elimination !");
                    break;
                }

                if (cartej1.GetTete())
                {
                    //var challengeurGagne = joueur1.Defis(cartej1, joueur2, tas);
                    var challengePerd = joueur1.Defis(cartej1, joueur2, tas);
                    if (challengePerd)
                    {
                        Console.WriteLine(joueur2.Nom + " n'a plus de carte ! Elimination !");
                        break;
                    }
                    
                    //if (challengeurGagne)
                    //{
                    //}
                    //else
                    //{
                    //    //var joueurTmp = joueur1;
                    //    //joueur1 = joueur2;
                    //    //joueur2 = joueurTmp;
                    //}
                }
            }

            if (joueur1.Cartes.Element == null) Console.WriteLine(joueur2.Nom + " gagne ! Il a " + joueur2.Cartes.nbElement + " cartes");
            if (joueur2.Cartes.Element == null) Console.WriteLine(joueur1.Nom + " gagne ! Il a " + joueur1.Cartes.nbElement + " cartes");
        }
    }
}
