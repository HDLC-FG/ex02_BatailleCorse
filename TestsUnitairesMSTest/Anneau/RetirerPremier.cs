using ex02_BatailleCorse;
using static ex02_BatailleCorse.Enums;

namespace TestsUnitairesMSTest.Anneau
{
    [TestClass]
    public sealed class RetirerPremier
    {
        [TestMethod]
        public void T01_RetirerPremier_Element_IsNull_ReturnNull()
        {
            var anneau = new Anneau<Carte>();

            var result = anneau.RetirerPremier();

            Assert.IsNull(result);
            Assert.AreEqual(anneau.nbElement, 0);
            Assert.IsNull(anneau.Element);
        }

        [TestMethod]
        public void T02_RetirerPremier_SingleElement_ReturnElementIsNull()
        {
            var anneau = new Anneau<Carte>
            {
                Element = new Maillon<Carte>
                {
                    Valeur = new Carte(Valeur.Valet, Couleur.Pique)
                },
                nbElement = 1
            };
            var carte = new Carte(Valeur.As, Couleur.Coeur);

            var result = anneau.RetirerPremier();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Valeur, Valeur.Valet);
            Assert.AreEqual(result.Couleur, Couleur.Pique);
            Assert.AreEqual(anneau.nbElement, 0);
            Assert.IsNull(anneau.Element);
        }

        [TestMethod]
        public void T03_RetirerPremier_MultipleElement_ReturnElement()
        {
            var anneau = new Anneau<Carte>
            {
                Element = new Maillon<Carte>
                {
                    Suivant = new Maillon<Carte>
                    {
                        Valeur = new Carte(Valeur.Dame, Couleur.Carreau)
                    },
                    Valeur = new Carte(Valeur.Valet, Couleur.Pique)
                },
                nbElement = 2
            };

            var result = anneau.RetirerPremier();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Valeur, Valeur.Valet);
            Assert.AreEqual(result.Couleur, Couleur.Pique);
            Assert.AreEqual(anneau.nbElement, 1);
            Assert.IsNotNull(anneau.Element);
            var element = anneau.Element.Valeur;
            Assert.AreEqual(element.Valeur, Valeur.Dame);
            Assert.AreEqual(element.Couleur, Couleur.Carreau);
        }
    }
}
