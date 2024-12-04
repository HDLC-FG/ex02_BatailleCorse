namespace ex02_BatailleCorse
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            var joueur1 = new Joueur("Julie");
            var joueur2 = new Joueur("Maxime");
            var joueur3 = new Joueur("Mélanie");
            var tas = new Anneau<Carte>();

            for (int i = 0; i < 16; i++)
            {
                joueur1.Cartes.AjouterALaFin(Joueur.GetRandomCarte());
                joueur2.Cartes.AjouterALaFin(Joueur.GetRandomCarte());
                joueur3.Cartes.AjouterALaFin(Joueur.GetRandomCarte());
            }

            var joueurs = new Anneau<Joueur>();
            joueurs.AjouterALaFin(joueur1);
            joueurs.AjouterALaFin(joueur2);
            joueurs.AjouterALaFin(joueur3);

            Carte? cartej1;

            while (true)
            {
                if (joueurs.nbElement == 1)
                {
                    var vainqueur = joueurs.Element.Valeur;
                    Console.WriteLine(vainqueur.Nom + " gagne !");
                    break;
                }
                var j1 = joueurs.RetirerPremier();
                var j2 = joueurs.RetirerPremier();

                cartej1 = j1.JouerUneCarte(tas);
                if (cartej1 == null)
                {
                    Console.WriteLine(j1.Nom + " n'a plus de carte ! Elimination !");
                    joueurs.AjouterALaFin(j2);
                    continue;
                }

                if (cartej1.GetTete())
                {
                    var challengeElimine = j1.Defis(cartej1, ref j1, ref j2, tas);
                    if (challengeElimine)
                    {
                        Console.WriteLine(j2.Nom + " n'a plus de carte ! Elimination !");
                        joueurs.AjouterALaFin(j1);
                        continue;
                    }
                }

                joueurs.AjouterALaFin(j1);
                joueurs.AjouterALaFin(j2);
            }
        }
    }
}
