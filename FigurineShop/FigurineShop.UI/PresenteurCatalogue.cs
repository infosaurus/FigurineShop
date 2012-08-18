using System.Collections.Generic;
using FigurineShop.Entites;
using FigurineShop.Interacteurs;

namespace FigurineShop.UI
{
    public class PresenteurCatalogue
    {
        private readonly IInteracteurCatalogue interacteurCatalogue;

        public PresenteurCatalogue(IInteracteurCatalogue interacteurCatalogue)
        {
            this.interacteurCatalogue = interacteurCatalogue;
        }

        public IList<Figurine> Catalogue()
        {
            return interacteurCatalogue.Catalogue();
        }
    }
}