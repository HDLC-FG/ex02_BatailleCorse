using ex02_BatailleCorse;
using static ex02_BatailleCorse.Enums;

namespace TestsUnitairesMSTest.Partie
{
    [TestClass]
    public sealed class Defi
    {
        [TestMethod]
        public void T01_Defi_J1_UneCarte_J2_PasDeCarte_JeuTermine()
        {
            var tas = new Anneau<Carte>(); 
            var joueurs = new Anneau<ex02_BatailleCorse.Joueur>();
            var joueur1 = new ex02_BatailleCorse.Joueur("Julie");
            var joueur2 = new ex02_BatailleCorse.Joueur("Maxime");

            joueur1.Cartes.AjouterALaFin(new Carte(Valeur.As, Couleur.Coeur));

            joueur1.JouerUneCarte(tas);

            bool stop = false;
            var partie = new ex02_BatailleCorse.Partie(ref joueurs, ref tas, ref joueur1, ref joueur2);

            stop = partie.Defi(stop);

            Assert.IsTrue(stop);
        }

        [TestMethod]
        public void T02_Defi_J1_UneCarte_J2_UneCarte_J3_JeuContinue()
        {
            var tas = new Anneau<Carte>(); 
            var joueurs = new Anneau<ex02_BatailleCorse.Joueur>();
            var joueur1 = new ex02_BatailleCorse.Joueur("Julie");
            var joueur2 = new ex02_BatailleCorse.Joueur("Maxime");
            var joueur3 = new ex02_BatailleCorse.Joueur("Mélanie");

            joueur1.Cartes.AjouterALaFin(new Carte(Valeur.As, Couleur.Coeur));
            joueur2.Cartes.AjouterALaFin(new Carte(Valeur.Sept, Couleur.Pique));

            joueur1.JouerUneCarte(tas);

            bool stop = false;
            var partie = new ex02_BatailleCorse.Partie(ref joueurs, ref tas, ref joueur1, ref joueur2);

            stop = partie.Defi(stop);

            Assert.IsFalse(stop);
        }
    }
}
