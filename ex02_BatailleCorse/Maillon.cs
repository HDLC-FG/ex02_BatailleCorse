namespace ex02_BatailleCorse
{
    public class Maillon<T>
    {
        public T Valeur { get; set; }
        public Maillon<T> Suivant { get; set; }

        //public Maillon(T valeur)
        //{
        //    Valeur = valeur;
        //}

        //public Maillon(T valeur, Maillon<T>? suivant = null)
        //{
        //    Valeur = valeur;
        //    Suivant = suivant;
        //}
    }
}
