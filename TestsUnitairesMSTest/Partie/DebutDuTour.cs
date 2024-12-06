using ex02_BatailleCorse;
using static ex02_BatailleCorse.Enums;

namespace TestsUnitairesMSTest.Partie
{
    [TestClass]
    public sealed class DebutDuTour
    {
        [TestMethod]
        public void T01_DebutDuTour_J1_PasDeCarte_J2_JeuTermine()
        {
            var tas = new Anneau<Carte>();
            var joueurs = new Anneau<ex02_BatailleCorse.Joueur>();
            var joueur1 = new ex02_BatailleCorse.Joueur("Julie");
            var joueur2 = new ex02_BatailleCorse.Joueur("Maxime");

            bool stop = false;
            var partie = new ex02_BatailleCorse.Partie(ref joueurs, ref tas, ref joueur1, ref joueur2);

            stop = partie.DebutDuTour(stop);

            Assert.IsTrue(stop);
        }

        [TestMethod]
        public void T02_DebutDuTour_J1_UneCarte_J2_JeuContinue()
        {
            var tas = new Anneau<Carte>();
            var joueurs = new Anneau<ex02_BatailleCorse.Joueur>();
            var joueur1 = new ex02_BatailleCorse.Joueur("Julie");
            var joueur2 = new ex02_BatailleCorse.Joueur("Maxime");

            joueur1.Cartes.AjouterALaFin(new Carte(Valeur.As, Couleur.Coeur));

            bool stop = false;
            var partie = new ex02_BatailleCorse.Partie(ref joueurs, ref tas, ref joueur1, ref joueur2);

            stop = partie.DebutDuTour(stop);

            Assert.IsFalse(stop);
        }

        [TestMethod]
        public void T02_DebutDuTour_J1_PasDeCarte_J2_J3_JeuContinueEtJ1Elimine()
        {
            var tas = new Anneau<Carte>();
            var joueurs = new Anneau<ex02_BatailleCorse.Joueur>();
            var joueur1 = new ex02_BatailleCorse.Joueur("Julie");
            var joueur2 = new ex02_BatailleCorse.Joueur("Maxime");
            var joueur3 = new ex02_BatailleCorse.Joueur("Mélanie");

            joueurs.AjouterALaFin(joueur3);

            bool stop = false;
            var partie = new ex02_BatailleCorse.Partie(ref joueurs, ref tas, ref joueur1, ref joueur2);

            stop = partie.DebutDuTour(stop);

            Assert.IsFalse(stop);
            Assert.IsNull(joueurs.Element);
            Assert.AreEqual(joueurs.nbElement, 0);
        }
    }
}
