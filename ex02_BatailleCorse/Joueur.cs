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

        public bool? Defi(Anneau<Joueur> joueurs, Joueur joueurChallenge, Anneau<Carte> tas)
        {
            //return true si la challengé pose une tete et provoque un nouveau défi, false si pas de nouveau défi et null si le challengé est éliminé
            Carte? carteChallenge;
            var carteChallengeur = tas.LireDernier();
            bool nouveauDefi = false;

            for (int i = 0; i < carteChallengeur.GetNombreDeTentatives(); i++)
            {
                carteChallenge = joueurChallenge.JouerUneCarte(tas, (i + 1) + " sur " + carteChallengeur.GetNombreDeTentatives());
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

        public static void Suivant(Anneau<Joueur> joueurs, ref Joueur? j1, ref Joueur? j2)
        {
            if (joueurs.nbElement == 0)
            {
                //2 joueurs
                joueurs.AjouterALaFin(j2);
                joueurs.AjouterALaFin(j1);
                j1 = joueurs.RetirerPremier();
                j2 = joueurs.RetirerPremier();
            }
            else
            {
                //3 joueurs et plus
                joueurs.AjouterALaFin(j1);
                joueurs.AjouterALaFin(j2);
                j1 = joueurs.RetirerPremier();
                j2 = joueurs.RetirerPremier();
            }
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
