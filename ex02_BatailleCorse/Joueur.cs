using static ex02_BatailleCorse.Enums;

namespace ex02_BatailleCorse
{
    internal class Joueur
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

        public bool Defis(Carte carteChallengeur, ref Joueur joueurChallengeur, ref Joueur joueurChallenge, Anneau<Carte> tas)
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
                joueurChallengeur.Cartes.AjouterAnneauALaFin(tas);
                Console.WriteLine("Le défi est gagné ! " + joueurChallengeur.Nom + " remporte " + tas.nbElement + " cartes !");
                tas.Element = null;
                tas.nbElement = 0;

                var joueurTmp = joueurChallenge;
                joueurChallenge = joueurChallengeur;
                joueurChallengeur = joueurTmp;
            }

            return false;
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
