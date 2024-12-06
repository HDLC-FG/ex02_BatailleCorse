using static ex02_BatailleCorse.Enums;

namespace ex02_BatailleCorse
{
    public class Joueur
    {
        private static Random random = new Random();
        private static Array? enumType = Enum.GetValues(typeof(Valeur));
        private static Array? enumCouleur = Enum.GetValues(typeof(Couleur));

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
                Console.WriteLine(Nom + " joue un " + carte.Valeur + " de " + carte.Couleur + " !");
                tas.AjouterALaFin(carte);
                return carte;
            }
            else
            {
                Console.WriteLine(Nom + " n'a plus de cartes !");
                return null;
            }
        }

        public bool? Defi(Joueur joueurChallenge, Anneau<Joueur> joueurs, Anneau<Carte> tas)
        {
            //return true si la challengé pose une tete et provoque un nouveau défi, false si pas de nouveau défi et null si le challengé est éliminé
            Carte? carteChallenge;
            bool nouveauDefi = false;
            var carteChallengeur = tas.LireDernier();

            for (int i = 0; i < carteChallengeur.GetNombreDeTentatives(); i++)
            {
                carteChallenge = joueurChallenge.JouerUneCarte(tas);
                if (carteChallenge == null) return null;

                if (carteChallenge.IsTete())
                {
                    nouveauDefi = true;
                    break;
                }
            }

            if (!nouveauDefi)
            {
                Cartes.AjouterAnneauALaFin(tas);
                Console.WriteLine("Le défi est gagné ! " + Nom + " remporte " + tas.nbElement + " cartes !\n");
                tas.Element = null;
                tas.nbElement = 0;
            }

            return nouveauDefi;
        }

        public static Carte GetRandomCarte()
        {
            var type = enumType?.GetValue(random.Next(0, 8));
            var couleur = enumCouleur?.GetValue(random.Next(0, 3));
            return new Carte((Valeur)type, (Couleur)couleur);
        }
    }
}
