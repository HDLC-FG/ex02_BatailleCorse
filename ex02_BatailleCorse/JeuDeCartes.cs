using System.Threading.Tasks;

namespace ex02_BatailleCorse
{
    internal class JeuDeCartes
    {
        private Random random;
        public Array? enumCarte {  get; private set; }

        public enum Carte
        {
            As,
            Sept,
            Huit,
            Neuf,
            Dix,
            Valet,
            Dame,
            Roi
        }

        public enum CarteDefis
        {
            As,
            Valet,
            Dame,
            Roi
        }

        public JeuDeCartes()
        {
            random = new Random();
            enumCarte = Enum.GetValues(typeof(Carte));
        }

        public Carte GetRandomCarte()
        {
            var carte = enumCarte?.GetValue(random.Next(0, 8));
            return carte == null ? throw new Exception() : (Carte)carte;
        }

        public static bool JouerUneCarte(Anneau<Maillon<Carte>> joueur, Anneau<Maillon<Carte>> tas, out Maillon<Carte> carte)
        {
            carte = joueur.RetirerPremier();
            if (carte != null)
            {
                tas.AjouterALaFin(carte);
                return true;
            }
            else
            {
                Console.WriteLine(joueur.nom + " n'a plus de cartes !");
                return false;
            }
        }
    }
}
