using System;
using System.Collections.Generic;
using FigurineShop.Entites;

namespace FigurineShop.Interacteurs
{
    public class ModeleReponsePanier
    {
        private IDictionary<Figurine, int> figurines;
        private float montant;

        public ModeleReponsePanier(IDictionary<Figurine, int> figurines, float total)
        {
            this.figurines = figurines;
            this.montant = total;
        }

        public IDictionary<Figurine, int> Figurines
        {
            get { return figurines; }
        }

        public float Montant
        {
            get {
                return montant;
            }
        }
    }
}