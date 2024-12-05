using static ex02_BatailleCorse.Enums;

namespace ex02_BatailleCorse
{
    public class Joueur
    {
        private static Random random = new Random();
        private static Array? enumType;
        private static Array? enumCouleur;

        public Anneau<Carte> Cartes { get; set; }
        public string Nom { get; set; }

        public Joueur(string nom)
        {
            Cartes = new Anneau<Carte>();
            Nom = nom;
        }

        public Joueur()
        {
        }

        public Carte? JouerUneCarte(Anneau<Carte> tas, string tentative = "")
        {
            if (Cartes.nbElement <= 0) return null;
            var carte = Cartes.RetirerPremier();
            if (carte != null)
            {
                Console.WriteLine(Nom + " joue un " + carte.Valeur + " de " + carte.Couleur + " ! " + tentative + " " + Nom + " a " + Cartes.nbElement + " cartes");
                tas.AjouterALaFin(carte);
                return carte;
            }
            else
            {
                Console.WriteLine(Nom + " n'a plus de cartes !");
                return null;
            }
        }

        public bool? Defis(Carte carteChallengeur, Anneau<Joueur> joueurs, Joueur joueurChallengeur, Joueur joueurChallenge, Anneau<Carte> tas)
        {
            //return true si le challengeur (j1) gagne, false si le challengé (j2) gagne et null si j2 n'a plus de cartes
            Carte? carteChallenge;
            carteChallengeur = tas.LireDernier();
            bool challengeurGagne = true;

            for (int i = 0; i < carteChallengeur.GetNombreDeTentatives(); i++)
            {
                carteChallenge = joueurChallenge.JouerUneCarte(tas, (i + 1) + " sur " + carteChallengeur.GetNombreDeTentatives());
                if (carteChallenge == null) return null;

                if (carteChallenge.IsTete())
                {
                    challengeurGagne = false;
                    break;
                }
            }

            if (challengeurGagne)
            {
                joueurChallengeur.Cartes.AjouterAnneauALaFin(tas);
                Console.WriteLine("Le défi est gagné ! " + joueurChallengeur.Nom + " remporte " + tas.nbElement + " cartes !\n");
                tas.Element = null;
                tas.nbElement = 0;
            }

            return challengeurGagne;
        }

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
