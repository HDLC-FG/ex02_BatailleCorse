namespace ex02_BatailleCorse
{
    public class Carte
    {
        public Couleur couleur { get; set; }
        public int Valeur;
    }

    public enum Couleur
    {
        Coeur,
        Carreau,
        Pique,
        Trefle
    }
}
