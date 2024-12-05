using static ex02_BatailleCorse.Enums;

namespace ex02_BatailleCorse
{
    public class Carte
    {
        public Valeur Valeur { get; set; }
        public Couleur Couleur { get; set; }

        public Carte(Valeur valeur, Couleur couleur)
        {
            Valeur = valeur;
            Couleur = couleur;
        }

        public Carte()
        {
        }

        public int GetNombreDeTentatives()
        {
            switch(Valeur)
            {
                case Valeur.As:
                    return 1;
                case Valeur.Roi:
                    return 2;
                case Valeur.Dame:
                    return 3;
                case Valeur.Valet:
                    return 4;
                default:
                    return 0;
            }
        }

        public bool IsTete()
        {
            switch (Valeur)
            {
                case Valeur.As:
                case Valeur.Roi:
                case Valeur.Dame:
                case Valeur.Valet:
                    return true;
                default:
                    return false;
            }
        }
    }
}
