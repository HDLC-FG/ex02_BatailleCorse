using static ex02_BatailleCorse.JeuDeCartes;

namespace ex02_BatailleCorse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var joueur1 = new Anneau<Maillon<Carte>>();    //joueur 1 = 16 cartes
            joueur1.nom = "Maxime";
            var joueur2 = new Anneau<Maillon<Carte>>();    //joueur 2 = 16 cartes
            joueur2.nom = "Lucie";
            var tas = new Anneau<Maillon<Carte>>();

            var jeuDeCarte = new JeuDeCartes();
            for (int i = 0; i < 4; i++)
            {
                joueur1.AjouterALaFin(new Maillon<Carte>(jeuDeCarte.GetRandomCarte()));
                joueur2.AjouterALaFin(new Maillon<Carte>(jeuDeCarte.GetRandomCarte()));
            }

            var cartej1 = JouerUneCarte(joueur1, tas);
            var cartej2 = JouerUneCarte(joueur2, tas);

            while (cartej1 != null && cartej2 != null)
            {
                cartej1 = JouerUneCarte(joueur1, tas);
                if (cartej1 == null) { break; }

                cartej2 = JouerUneCarte(joueur2, tas);
                if (cartej2 == null) { break; }

                for (int i = 0; i < GetNombreDeTentatives(cartej1); i++)
                {
                    if (!GetTete(cartej2))
                    {
                        Console.WriteLine("Le défi est perdu ! joue un " + joueur1.nom + " remporte " + tas.nbElement + " cartes !");
                        joueur1.AjouterAnneauLaFin(tas);
                        break;
                    }
                    else
                    {
                        cartej2 = JouerUneCarte(joueur2, tas);
                        if (cartej2 == null) { break; }
                    }
                }

                for (int i = 0; i < GetNombreDeTentatives(cartej2); i++)
                {
                    if (!GetTete(cartej1))
                    {
                        Console.WriteLine("Le défi est perdu ! joue un " + joueur2.nom + " remporte " + tas.nbElement + " cartes !");
                        joueur2.AjouterAnneauLaFin(tas);
                        break;
                    }
                    else
                    {
                        cartej1 = JouerUneCarte(joueur1, tas);
                        if (cartej1 == null) { break; }
                    }
                }
            }

            if (joueur1.Element == null) Console.WriteLine(joueur2.nom + " gagne !");
            if (joueur2.Element == null) Console.WriteLine(joueur1.nom + " gagne !");
        }
    }
}
