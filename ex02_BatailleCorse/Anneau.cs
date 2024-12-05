namespace ex02_BatailleCorse
{
    public class Anneau<T>
    {
        public int nbElement = 0;
        public Maillon<T>? Element { get; set; }

        public void AjouterALaFin(T element)
        {
            if(Element == null)
            {
                Element = new Maillon<T> { Valeur = element };
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
                        maillon.Suivant = new Maillon<T> { Valeur = element };
                    }
                }
            }
            nbElement++;
        }

        public void AjouterAnneauALaFin(Anneau<T> anneau)
        {
            if(anneau == null) return;
            if (Element == null)
            {
                Element = anneau.Element;
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
                        maillon.Suivant = anneau.Element;
                    }
                }
            }
            nbElement += anneau.nbElement;
        }

        public T? RetirerPremier()
        {
            if (Element == null) return default;
            var valuePremier = Element.Valeur;
            Element = Element.Suivant;
            nbElement--;
            return valuePremier;
        }

        public T? LireDernier()
        {
            Maillon<T>? maillon = Element;

            for (int i = 1; i < nbElement; i++)
            {
                maillon = maillon != null ? maillon.Suivant : maillon;
            }

            return maillon.Valeur;
        }
    }
}
