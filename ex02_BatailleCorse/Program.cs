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
            var tas = new Anneau<Maillon<Carte>>();    //joueur 2 = 16 cartes

            var jeuDeCarte = new JeuDeCartes();
            for (int i = 0; i < 16; i++)
            {
                joueur1.AjouterALaFin(new Maillon<Carte>(jeuDeCarte.GetRandomCarte()));
                joueur2.AjouterALaFin(new Maillon<Carte>(jeuDeCarte.GetRandomCarte()));
            }

            //while (true)
            //{
            //    if(!JouerUneCarte(joueur1, tas, out Maillon<Carte> cartej1)) { break; }
            //    if(!JouerUneCarte(joueur2, tas, out Maillon<Carte> cartej2)) { break; }

            //    if((int)cartej1.Valeur == 0
            //        || (int)cartej1.Valeur == 4
            //        || (int)cartej1.Valeur == 5
            //        || (int)cartej1.Valeur == 6
            //        || (int)cartej1.Valeur == 7)
            //    {

            //    }

            //    Console.WriteLine("Hello, World!");
            //}

            Console.WriteLine("Hello, World!");
        }
    }
}
