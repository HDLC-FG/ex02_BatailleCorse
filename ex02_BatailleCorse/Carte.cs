using static ex02_BatailleCorse.Enums;

namespace ex02_BatailleCorse
{
    public class Carte
    {
        //private Random random;
        //private Array? enumType;
        //private Array? enumCouleur;
        public Valeur Valeur { get; set; }
        public Couleur Couleur { get; set; }

        public Carte(Valeur valeur, Couleur couleur)
        {
            Valeur = valeur;
            Couleur = couleur;
        }



        //public Carte()
        //{
        //    random = new Random();
        //    enumType = Enum.GetValues(typeof(Valeur));
        //    enumCouleur = Enum.GetValues(typeof(Couleur));
        //}

        //public Carte GetRandomCarte()
        //{
        //    var type = enumType?.GetValue(random.Next(0, 8));
        //    var couleur = enumCouleur?.GetValue(random.Next(0, 3));
        //    return new Carte { Valeur = (Valeur)type, Couleur = (Couleur)couleur };
        //}

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

        public bool GetTete()
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
