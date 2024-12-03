namespace ex02_BatailleCorse
{
    public class ListChaineGeneric<T>
    {
        public T Valeur { get; set; }
        public ListChaineGeneric<T> Precedent { get; set; }
        public ListChaineGeneric<T> Suivant
        {
            get
            {
                if (Precedent == null) return null;
                ListChaineGeneric<T> dernier = Precedent;
                while (dernier.Suivant != null)
                {
                    dernier = dernier.Suivant;
                }
                return dernier;
            }
            set
            {
                Suivant = value;
            }
        }

        public void Ajouter(T element)
        {
            if (Precedent == null)
            {
                Precedent = new ListChaineGeneric<T> { Valeur = element };
            }
            else
            {
                ListChaineGeneric<T> dernier = this;
                dernier.Suivant = new ListChaineGeneric<T> { Valeur = element, Precedent = dernier };
            }
        }
    }
}
