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

            bool stop = false;
            Carte? cartej1 = new Carte();
            Joueur? j1 = joueurs.RetirerPremier();
            Joueur? j2 = joueurs.RetirerPremier();

            var partie = new Partie(ref joueurs, ref tas, ref j1, ref j2);

            while (!stop)
            {
                stop = partie.DebutDuTour(stop);

                stop = partie.Defi(stop);

                partie.FinDeTour(stop);
            }
        }
    }
}
