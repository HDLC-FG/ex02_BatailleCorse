using ex02_BatailleCorse;

namespace TestsUnitairesMSTest.Anneau
{
    [TestClass]
    public sealed class Suivant
    {
        [TestMethod]
        public void T01_Suivant_J1_J2_J2J1()
        {
            var joueur1 = new ex02_BatailleCorse.Joueur("Julie");
            var joueur2 = new ex02_BatailleCorse.Joueur("Maxime");

            var joueurs = new Anneau<ex02_BatailleCorse.Joueur>();

            joueurs.Suivant(ref joueur1, ref joueur2);

            Assert.IsNotNull(joueurs);
            Assert.AreEqual(joueurs.nbElement, 0);
            Assert.IsNotNull(joueur1);
            Assert.AreEqual(joueur1.Nom, "Maxime");
            Assert.IsNotNull(joueur2);
            Assert.AreEqual(joueur2.Nom, "Julie");
        }
    }
}
