using FigurineShop.Entites;
using FigurineShop.Interacteurs;

namespace FigurineShop.UI
{
    public class PresenteurAjoutFigurine
    {
        private readonly IInteracteurAjoutFigurine interacteur;

        public PresenteurAjoutFigurine(IInteracteurAjoutFigurine interacteur)
        {
            this.interacteur = interacteur;
        }

        public void AjouterFigurine(Figurine figurine)
        {
            interacteur.AjouterFigurine(figurine);
        }
    }
}