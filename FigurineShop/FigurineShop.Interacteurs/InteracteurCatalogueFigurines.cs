using System.Collections.Generic;
using FigurineShop.Bornes;
using FigurineShop.Entites;

namespace FigurineShop.Interacteurs
{
    public class InteracteurCatalogueFigurines : IInteracteurCatalogue
    {
        private readonly IEntrepotFigurines entrepotFigurines;

        public InteracteurCatalogueFigurines(IEntrepotFigurines entrepotFigurines)
        {
            this.entrepotFigurines = entrepotFigurines;
        }

        public IList<Figurine> Catalogue()
        {
            var toutesFigurines = entrepotFigurines.ToutesFigurines();
            if (toutesFigurines == null)
                return new List<Figurine>();
            return toutesFigurines;
        }
    }

    public interface IInteracteurCatalogue
    {
        IList<Figurine> Catalogue();
    }
}