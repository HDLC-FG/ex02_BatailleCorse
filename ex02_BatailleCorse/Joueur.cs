using static ex02_BatailleCorse.Enums;

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

        public bool Defis(Carte carteChallengeur, Joueur joueurChallenge, Anneau<Carte> tas)
        {
            Carte? carteChallenge;
            bool challengeurGagne = true;

            for (int i = 0; i < carteChallengeur.GetNombreDeTentatives(); i++)
            {
                carteChallenge = joueurChallenge.JouerUneCarte(tas);
                if (carteChallenge == null) return true;

                if (carteChallenge.GetTete())
                {
                    challengeurGagne = false;
                    break;
                }
            }

            if(challengeurGagne)
            {
                Cartes.AjouterAnneauALaFin(tas);
                Console.WriteLine("Le défi est gagné ! " + Nom + " remporte " + tas.nbElement + " cartes !");
                tas.Element = null;
                tas.nbElement = 0;   //le challengeur a gagné, à lui de rejouer

                //var joueurTmp = joueur1;
                //    //joueur1 = joueur2;
                //    //joueur2 = joueurTmp;
            }

            return false;
            //else
            //{
            //    joueurChallenge.Cartes.AjouterAnneauALaFin(tas);
            //    Console.WriteLine("Le défi est gagné ! " + joueurChallenge.Nom + " remporte " + tas.nbElement + " cartes !");
            //    tas.Element = null;
            //    tas.nbElement = 0;
            //    return false;   //j2 a gagne, j1 doit rejouer

            //}
        }

        private static Random random = new Random();
        private static Array? enumType;
        private static Array? enumCouleur;

        public static Carte GetRandomCarte()
        {
            enumType = Enum.GetValues(typeof(Valeur));
            enumCouleur = Enum.GetValues(typeof(Couleur));
            var type = enumType?.GetValue(random.Next(0, 8));
            var couleur = enumCouleur?.GetValue(random.Next(0, 3));
            return new Carte((Valeur)type, (Couleur)couleur);
        }
    }
}
