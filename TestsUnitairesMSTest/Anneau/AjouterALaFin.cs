using ex02_BatailleCorse;
using static ex02_BatailleCorse.Enums;

namespace TestsUnitairesMSTest.Anneau
{
    [TestClass]
    public sealed class AjouterALaFin
    {
        [TestMethod]
        public void T01_AjouterALaFin_Element_IsNull_AddCarte()
        {
            var anneau = new Anneau<Carte>();
            var carte = new Carte(Valeur.As, Couleur.Coeur);

            anneau.AjouterALaFin(carte);

            Assert.AreEqual(anneau.nbElement, 1);
            Assert.IsNotNull(anneau.Element);
            Assert.AreEqual(anneau.Element.Valeur.Valeur, Valeur.As);
            Assert.AreEqual(anneau.Element.Valeur.Couleur, Couleur.Coeur);
        }

        [TestMethod]
        public void T02_AjouterALaFin_Element_Exist_AddCarte()
        {
            var anneau = new Anneau<Carte>(new Maillon<Carte>(new Carte(Valeur.Valet, Couleur.Pique)));
            var carte = new Carte(Valeur.As, Couleur.Coeur);

            anneau.AjouterALaFin(carte);

            Assert.AreEqual(anneau.nbElement, 2);
            Assert.IsNotNull(anneau.Element);
            Assert.IsNotNull(anneau.Element.Suivant);
            var element = anneau.Element.Suivant.Valeur;
            Assert.AreEqual(element.Valeur, Valeur.As);
            Assert.AreEqual(element.Couleur, Couleur.Coeur);
        }
    }
}
