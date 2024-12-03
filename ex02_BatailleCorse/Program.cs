namespace ex02_BatailleCorse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var joueur1 = new Anneau<Maillon<int>>();    //joueur 1 = 16 cartes
            var joueur2 = new Anneau<Maillon<int>>();    //joueur 2 = 16 cartes
            
            var random = new Random();
            joueur1.AjouterALaFin(new Maillon<int>(random.Next(1, 9)));
            joueur1.AjouterALaFin(new Maillon<int>(random.Next(1, 9)));
            joueur1.AjouterALaFin(new Maillon<int>(random.Next(1, 9)));
            joueur1.AjouterALaFin(new Maillon<int>(random.Next(1, 9)));

            //var test = new ListChaineGeneric<int>();
            //test.Ajouter(1);
            //test.Ajouter(2);
            //test.Ajouter(3);

            //var carte = new Maillon<int>();
            //carte.Valeur = random.Next(1, 9);
            //carte.AjouterALaFin(carte);

            //for (int i = 1; i <= 16; i++)
            //{
            //    carte.AjouterALaFin(random.Next(1, 9));
            //    joueur1.AjouterALaFin(carte);   // un nombre en 1 et 8
            //    //joueur2.AjouterALaFin(random.Next(1, 9));   // un nombre en 1 et 8
            //}

            Console.WriteLine("Hello, World!");
        }
    }
}
