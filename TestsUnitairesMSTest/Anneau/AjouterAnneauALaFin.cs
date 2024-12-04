using ex02_BatailleCorse;
using static ex02_BatailleCorse.Enums;

namespace TestsUnitairesMSTest.Anneau
{
    [TestClass]
    public sealed class AjouterAnneauALaFin
    {
        [TestMethod]
        public void T01_AjouterAnneauLaFin_Element_IsNull_AddCarte()
        {
            var anneau = new Anneau<Carte>();
            var anneauAAjouter = new Anneau<Carte>
            {
                Element = new Maillon<Carte>
                {
                    Suivant = new Maillon<Carte>
                    {
                        Valeur = new Carte(Valeur.As, Couleur.Pique)
                    },
                    Valeur = new Carte(Valeur.Dame, Couleur.Coeur)
                },
                nbElement = 2
            };

            anneau.AjouterAnneauALaFin(anneauAAjouter);

            Assert.IsNotNull(anneau.Element);
            var carte1 = anneau.Element.Valeur;
            Assert.AreEqual(carte1.Valeur, Valeur.Dame);
            Assert.AreEqual(carte1.Couleur, Couleur.Coeur);
            var carte2 = anneau.Element.Suivant.Valeur;
            Assert.AreEqual(carte2.Valeur, Valeur.As);
            Assert.AreEqual(carte2.Couleur, Couleur.Pique);
        }

        //[TestMethod]
        //public void T02_AjouterAnneauLaFin_Element_Exist_AddCarte()
        //{
        //    var anneau = new Anneau<Carte>
        //    {
        //        Element = new Maillon<Carte>
        //        {
        //            Valeur = new Carte(Valeur.Valet, Couleur.Pique)
        //        },
        //        nbElement = 1
        //    };
        //    var carte = new Carte(Valeur.As, Couleur.Coeur);

        //    anneau.AjouterALaFin(carte);

        //    Assert.IsNotNull(anneau.Element);
        //    Assert.IsNotNull(anneau.Element.Suivant);
        //    var element = anneau.Element.Suivant.Valeur;
        //    Assert.AreEqual(element.Valeur, Valeur.As);
        //    Assert.AreEqual(element.Couleur, Couleur.Coeur);
        //}
    }
}
