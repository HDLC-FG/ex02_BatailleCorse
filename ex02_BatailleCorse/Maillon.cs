namespace ex02_BatailleCorse
{
    public class Maillon<T>
    {
        public T Valeur { get; set; }
        public Maillon<T> Suivant { get; set; }
    }
}
