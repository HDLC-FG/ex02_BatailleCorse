namespace ex02_BatailleCorse
{
    public class Anneau<T>
    {
        private int nbElement = 0;
        public string nom { get; set; }
        public Maillon<T>? Element { get; set; }

        public void AjouterALaFin(T element)
        {
            if(Element == null)
            {
                Element = new Maillon<T>(element);
            }
            else
            {
                Maillon<T>? maillon = Element;
                for (int i = 0; i < nbElement; i++)
                {
                    if (maillon?.Suivant != null)
                    {
                        maillon = maillon.Suivant;
                    }
                    else
                    {
                        maillon.Suivant = new Maillon<T>(element);
                    }
                }
            }
            nbElement++;
        }

        public void Retirer(T element)
        {
            nbElement--;
            for (int i = 0; i < nbElement; i++)
            {
                var currentElement = RetirerPremier();
                if (currentElement != null && !currentElement.Equals(element)) AjouterALaFin(currentElement);
            }
        }

        public T? RetirerPremier()
        {
            nbElement--;
            if (Element == null) return default;
            var valuePremier = Element.Valeur;
            Element = Element.Suivant;
            return valuePremier;
        }
    }
}
