using ex02_BatailleCorse;

namespace TestsUnitairesMSTest.Joueur
{
    [TestClass]
    public class Defis
    {
        [TestMethod]
        public void T01_Defis_J1_As_J2_As_NouveauDefi()
        {
            var joueur1 = new ex02_BatailleCorse.Joueur("Julie");
            var joueur2 = new ex02_BatailleCorse.Joueur("Maxime");
            var tas = new Anneau<Carte>();

            joueur1.Cartes.AjouterALaFin(new Carte(Enums.Valeur.As, Enums.Couleur.Coeur));
            joueur2.Cartes.AjouterALaFin(new Carte(Enums.Valeur.As, Enums.Couleur.Carreau));

            var joueurs = new Anneau<ex02_BatailleCorse.Joueur>();
            joueurs.AjouterALaFin(joueur1);
            joueurs.AjouterALaFin(joueur2);

            joueur1.JouerUneCarte(tas);

            var nouveauDefi = joueur1.Defi(joueurs, joueur2, tas);

            Assert.IsTrue(nouveauDefi);
        }

        [TestMethod]
        public void T02_Defis_J1_As_J2_Sept_PasDeNouveauDefi()
        {
            var joueur1 = new ex02_BatailleCorse.Joueur("Julie");
            var joueur2 = new ex02_BatailleCorse.Joueur("Maxime");
            var tas = new Anneau<Carte>();

            joueur1.Cartes.AjouterALaFin(new Carte(Enums.Valeur.As, Enums.Couleur.Coeur));
            joueur2.Cartes.AjouterALaFin(new Carte(Enums.Valeur.Sept, Enums.Couleur.Carreau));

            var joueurs = new Anneau<ex02_BatailleCorse.Joueur>();
            joueurs.AjouterALaFin(joueur1);
            joueurs.AjouterALaFin(joueur2);
            //joueurs.AjouterALaFin(joueur3);

            joueur1.JouerUneCarte(tas);

            var nouveauDefi = joueur1.Defi(joueurs, joueur2, tas);

            Assert.IsFalse(nouveauDefi);
        }
    }
}
