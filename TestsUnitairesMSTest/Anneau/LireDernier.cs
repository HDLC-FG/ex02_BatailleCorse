using ex02_BatailleCorse;

namespace TestsUnitairesMSTest.Anneau
{
    [TestClass]
    public sealed class LireDernier
    {
        [TestMethod]
        public void T01_LireDernier_UneCarteJoue_Carte()
        {
            var joueur1 = new ex02_BatailleCorse.Joueur("Julie");
            var joueur2 = new ex02_BatailleCorse.Joueur("Maxime");
            var tas = new Anneau<Carte>();

            joueur1.Cartes.AjouterALaFin(new Carte(Enums.Valeur.Dame, Enums.Couleur.Coeur));

            joueur1.JouerUneCarte(tas);

            var result = tas.LireDernier();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Valeur, Enums.Valeur.Dame);
            Assert.AreEqual(result.Couleur, Enums.Couleur.Coeur);
        }

        [TestMethod]
        public void T02_LireDernier_TroisCartesJoue_Carte()
        {
            var joueur1 = new ex02_BatailleCorse.Joueur("Julie");
            var joueur2 = new ex02_BatailleCorse.Joueur("Maxime");
            var joueur3 = new ex02_BatailleCorse.Joueur("Mélanie");
            var tas = new Anneau<Carte>();

            joueur1.Cartes.AjouterALaFin(new Carte(Enums.Valeur.As, Enums.Couleur.Coeur));
            joueur2.Cartes.AjouterALaFin(new Carte(Enums.Valeur.Sept, Enums.Couleur.Pique)); 
            joueur3.Cartes.AjouterALaFin(new Carte(Enums.Valeur.Valet, Enums.Couleur.Trefle));

            joueur1.JouerUneCarte(tas);
            joueur2.JouerUneCarte(tas);
            joueur3.JouerUneCarte(tas);

            var result = tas.LireDernier();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Valeur, Enums.Valeur.Valet);
            Assert.AreEqual(result.Couleur, Enums.Couleur.Trefle);
        }
    }
}
