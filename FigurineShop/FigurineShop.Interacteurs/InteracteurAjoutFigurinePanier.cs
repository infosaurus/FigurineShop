using FigurineShop.Entites;

namespace FigurineShop.Interacteurs
{
    public class InteracteurAjoutFigurinePanier : IInteracteurAjoutFigurine
    {
        private readonly IPanierFigurines panierFigurines;

        public InteracteurAjoutFigurinePanier(IPanierFigurines panierFigurines)
        {
            this.panierFigurines = panierFigurines;
        }

        public void AjouterFigurine(Figurine figurine)
        {
            if (figurine != null)
                panierFigurines.AjouterFigurine(figurine);
        }
    }

    public interface IInteracteurAjoutFigurine
    {
        void AjouterFigurine(Figurine figurine);
    }
}