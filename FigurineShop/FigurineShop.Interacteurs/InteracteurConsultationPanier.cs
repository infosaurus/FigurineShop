using System.Collections.Generic;
using FigurineShop.Entites;

namespace FigurineShop.Interacteurs
{
    public class InteracteurConsultationPanier
    {
        private readonly IPanierFigurines panierFigurines;

        public InteracteurConsultationPanier(IPanierFigurines panierFigurines)
        {
            this.panierFigurines = panierFigurines;
        }

        public ModeleReponsePanier ConsulterPanier()
        {
            if (panierFigurines.Figurines == null)
                return new ModeleReponsePanier(new Dictionary<Figurine, int>(), panierFigurines.CalculeTotal());
            return new ModeleReponsePanier(panierFigurines.Figurines, panierFigurines.CalculeTotal());
        }
    }
}