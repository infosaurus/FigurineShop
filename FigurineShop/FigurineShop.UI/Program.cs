using System;
using FigurineShop.Entites;
using FigurineShop.Infrastructure;
using FigurineShop.Interacteurs;

namespace FigurineShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var panier = new PanierFigurines();
            var entrepotFigurines = new EntrepotMémoireFigurinesDémo();
            var presenteurCatalogue = new PresenteurCatalogue(new InteracteurCatalogueFigurines(entrepotFigurines));
            var presenteurAjoutFigurine = new PresenteurAjoutFigurine(new InteracteurAjoutFigurinePanier(panier));
            var presenteurPanier = new PresenteurPanier(new InteracteurConsultationPanier(panier));

            AfficheMenu();
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "4")
            {
                switch (input)
                {
                    case "1":
                        AfficheCatalogue(presenteurCatalogue);
                        break;
                    case "2":
                        AffichePanier(presenteurPanier);
                        break;
                    case "3":
                        SaisieFigurine(presenteurAjoutFigurine, presenteurCatalogue);
                        break;
                    default:
                        Console.WriteLine("Mauvaise saisie");
                        break;
                }
                AfficheMenu();
            }
        }

        private static void SaisieFigurine(PresenteurAjoutFigurine presenteurAjoutFigurine, PresenteurCatalogue presenteurCatalogue)
        {
            Console.Write("Numéro de la figurine dans le catalogue ? :");
            var numero = int.Parse(Console.ReadLine());
            if (numero < 1 || numero > presenteurCatalogue.Catalogue().Count)
            {
                Console.WriteLine("Saisie invalide.");
                return;
            }
            var figurine = presenteurCatalogue.Catalogue()[numero - 1];
            presenteurAjoutFigurine.AjouterFigurine(figurine);
            Console.WriteLine("Figurine ajoutée.");
        }

        private static void AffichePanier(PresenteurPanier presenteurPanier)
        {
            Console.WriteLine();
            presenteurPanier.Update();
            if (presenteurPanier.LignesPanier != null)
                foreach (var lignePanier in presenteurPanier.LignesPanier)
                    Console.WriteLine(lignePanier.Key.Nom + " .................... " + lignePanier.Value);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Total : " + presenteurPanier.MontantPanier + " Euros");
            Console.WriteLine();
        }

        private static void AfficheCatalogue(PresenteurCatalogue presenteurCatalogue)
        {
            Console.WriteLine();
            foreach (var figurine in presenteurCatalogue.Catalogue())
                Console.WriteLine(presenteurCatalogue.Catalogue().IndexOf(figurine) + 1 + "." + figurine.Nom);
            Console.WriteLine();
        }

        private static void AfficheMenu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("1. Consulter le catalogue");
            Console.WriteLine("2. Consulter le panier");
            Console.WriteLine("3. Ajouter une figurine au panier");
            Console.WriteLine("4. Sortir");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Console.Write("Choix ? : ");
        }
    }
}