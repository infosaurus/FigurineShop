using System.Collections.Generic;
using FigurineShop.Entites;

namespace FigurineShop.Bornes
{
    public interface IEntrepotFigurines
    {
        IList<Figurine> ToutesFigurines();
    }
}