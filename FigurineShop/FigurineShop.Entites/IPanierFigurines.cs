using System.Collections.Generic;

namespace FigurineShop.Entites
{
    public interface IPanierFigurines
    {
        void AjouterFigurine(Figurine figurine);
        IDictionary<Figurine, int >Figurines { get; }
        float CalculeTotal();
    }
}