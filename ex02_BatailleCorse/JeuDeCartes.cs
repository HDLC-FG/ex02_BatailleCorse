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
        public enum Couleur
        {
            Coeur,
            Carreau,
            Trefle,
            Pique
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

        public static Maillon<Carte>? JouerUneCarte(Anneau<Maillon<Carte>> joueur, Anneau<Maillon<Carte>> tas)
        {
            var carte = joueur.RetirerPremier();
            if (carte != null)
            {
                Console.WriteLine(joueur.nom + " joue un " + carte.Valeur + " !");
                tas.AjouterALaFin(carte);
                return carte;
            }
            else
            {
                Console.WriteLine(joueur.nom + " n'a plus de cartes !");
                return null;
            }
        }

        public static int GetNombreDeTentatives(Maillon<Carte> carte)
        {
            switch(carte.Valeur)
            {
                case Carte.As:
                    return 1;
                case Carte.Roi:
                    return 2;
                case Carte.Dame:
                    return 3;
                case Carte.Valet:
                    return 4;
                default:
                    return 0;
            }
        }

        public static bool GetTete(Maillon<Carte> carte)
        {
            switch (carte.Valeur)
            {
                case Carte.As:
                case Carte.Roi:
                case Carte.Dame:
                case Carte.Valet:
                    return true;
                default:
                    return false;
            }
        }
    }
}
