using System.Collections.Generic;
using System.Linq;

namespace FigurineShop.Entites
{
    public class PanierFigurines : IPanierFigurines
    {
        public const int PRIX_UNITAIRE_FIGURINE = 8;
        private float[] coefficientsRéduction = new[] {0, 1, 0.95f, 0.90f, 0.75f};
        private IDictionary<Figurine, int> figurines = new Dictionary<Figurine, int>();

        public IDictionary<Figurine, int> Figurines
        {
            get { return figurines; }
        }

        public float CalculeTotal()
        {
            if (ToutesFigurinesIdentiques())
                return PRIX_UNITAIRE_FIGURINE*figurines.First().Value;

            if (ToutesFigurinesDistinctes())
                return CalculeTotalAvecRéduction(figurines.Count);

            return SousPanierContenantLaPlusLongueSérie().CalculeTotal()
                   + SousPanierContenantLeReste().CalculeTotal();
        }

        private PanierFigurines SousPanierContenantLaPlusLongueSérie()
        {
            var sousPanier = new Dictionary<Figurine, int>(figurines);
            foreach (var figurine in figurines.Keys)
            {
                sousPanier[figurine] = 1;
            }
            return new PanierFigurines()
            {
                figurines = sousPanier
            };
        }

        private PanierFigurines SousPanierContenantLeReste()
        {
            var sousPanier = new Dictionary<Figurine, int>(figurines);
            foreach (var figurine in figurines.Keys)
            {
                if (sousPanier[figurine] == 1)
                    sousPanier.Remove(figurine);
                else
                    sousPanier[figurine]--;
            }
            return new PanierFigurines()
            {
                figurines = sousPanier
            };
        }

        private bool ToutesFigurinesDistinctes()
        {
            return figurines.All(kvp => kvp.Value == 1);
        }

        private bool ToutesFigurinesIdentiques()
        {
            return figurines.Count == 1;
        }

        private float CalculeTotalAvecRéduction(int nbFigurines)
        {
            return coefficientsRéduction[nbFigurines]*PRIX_UNITAIRE_FIGURINE*nbFigurines;
        }

        public void AjouterFigurine(Figurine figurine)
        {
            if (figurines.ContainsKey(figurine))
                figurines[figurine]++;
            else
                figurines.Add(figurine, 1);
        }
    }
}