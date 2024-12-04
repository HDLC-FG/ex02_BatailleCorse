namespace ex02_BatailleCorse
{
    internal class Joueur
    {
        public Anneau<Carte> Cartes { get; set; }
        public string Nom { get; set; }
        
        public Joueur(string nom) 
        {
            Cartes = new Anneau<Carte>();
            Nom = nom;
        }

        public Carte? JouerUneCarte(Anneau<Carte> tas)
        {
            if (Cartes.nbElement <= 0) return null;
            var carte = Cartes.RetirerPremier();
            if (carte != null)
            {
                Console.WriteLine(Nom + " joue un " + carte.Valeur + " de " + carte.Couleur + " ! " + Nom + " a " + Cartes.nbElement + " cartes");
                tas.AjouterALaFin(carte);
                return carte;
            }
            else
            {
                Console.WriteLine(Nom + " n'a plus de cartes !");
                return null;
            }
        }

        public bool Defis(Carte cartej1, Joueur joueur2, Anneau<Carte> tas)
        {
            Carte? cartej2;
            bool j1Gagne = true;

            for (int i = 0; i < cartej1.GetNombreDeTentatives(); i++)
            {
                cartej2 = joueur2.JouerUneCarte(tas);
                if (cartej2 == null) break;

                if (cartej2.GetTete())
                {
                    j1Gagne = false;
                    break;
                }
            }

            if(j1Gagne)
            {
                Cartes.AjouterAnneauALaFin(tas);
                Console.WriteLine("Le défi est gagné ! " + Nom + " remporte " + tas.nbElement + " ! A " + joueur2.Nom + " de jouer");
                tas.Element = null;
                tas.nbElement = 0;
                return true;    //j1 a gagne, j2 doit jouer
            }
            else
            {
                joueur2.Cartes.AjouterAnneauALaFin(tas);
                Console.WriteLine("Le défi est gagné ! " + joueur2.Nom + " remporte " + tas.nbElement + " ! A " + Nom + " de jouer");
                tas.Element = null;
                tas.nbElement = 0;
                return false;   //j2 a gagne, j1 doit rejouer

            }
        }
    }
}
