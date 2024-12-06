namespace ex02_BatailleCorse
{
    public class Maillon<T>
    {
        public T? Valeur { get; set; }
        public Maillon<T>? Suivant { get; set; }

        public Maillon()
        {
        }

        public Maillon(T valeur)
        {
            Valeur = valeur;
            Suivant = null;
        }

        public Maillon(T valeur, Maillon<T> suivant)
        {
            Valeur = valeur;
            Suivant = suivant;
        }
    }
}
