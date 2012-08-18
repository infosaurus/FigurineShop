using System.Collections.Generic;
using System.Linq;
using FigurineShop.Bornes;
using FigurineShop.Entites;

namespace FigurineShop.Infrastructure
{
    public class EntrepotMémoireFigurines : IEntrepotFigurines
    {
        protected IList<Figurine> figurines = new List<Figurine>();

        public EntrepotMémoireFigurines(IList<Figurine> figurines)
        {
            this.figurines = figurines;
        }

        public EntrepotMémoireFigurines()
        {

        }

        public IList<Figurine> ToutesFigurines()
        {
            return figurines;
        }
    }

    public class EntrepotDictionnaireFigurines : IEntrepotFigurines
    {
        private IDictionary<string, Figurine> figurines = new Dictionary<string, Figurine>();

        public EntrepotDictionnaireFigurines(IDictionary<string, Figurine> figurines)
        {
            this.figurines = figurines;
        }

        public EntrepotDictionnaireFigurines()
        {

        }

        public IList<Figurine> ToutesFigurines()
        {
            return figurines.Values.ToList();
        }
    }

    public class EntrepotMémoireFigurinesDémo : EntrepotMémoireFigurines
    {
        public EntrepotMémoireFigurinesDémo()
        {
            figurines.Add(new Figurine("Tintin"));
            figurines.Add(new Figurine("Milou"));
            figurines.Add(new Figurine("Capitaine Haddock"));
            figurines.Add(new Figurine("Professeur Tournesol"));
        }
    }
}