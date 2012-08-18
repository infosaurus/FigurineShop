using System.Collections.Generic;
using FigurineShop.Bornes;
using FigurineShop.Entites;
using FigurineShop.Infrastructure;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace FigurineShop.Tests
{
    [TestFixture]
    public abstract class EntrepotFigurineTest
    {
        [Test]
        public abstract void RetourneListeVideQuandPasDeFigurinesDansLEntrepot();

        [Test]
        public abstract void RetourneListeDeFigurinesContenuesDansLEntrepot();

    }

    [TestFixture]
    public class EntrepotFigurinesMémoireTest : EntrepotFigurineTest
    {
        [Test]
        public override void RetourneListeVideQuandPasDeFigurinesDansLEntrepot()
        {
            IEntrepotFigurines entrepotFigurines = new EntrepotMémoireFigurines();

            Assert.That(entrepotFigurines.ToutesFigurines(), Is.Empty);
        }

        [Test]
        public override void RetourneListeDeFigurinesContenuesDansLEntrepot()
        {
            var tintin = new Figurine("Tintin");
            var milou = new Figurine("Milou");
            var haddock = new Figurine("Haddock");
            var listeFigurines = new List<Figurine> { tintin, milou, haddock };
            IEntrepotFigurines entrepotFigurines = new EntrepotMémoireFigurines(listeFigurines);

            Assert.That(entrepotFigurines.ToutesFigurines(), Is.EqualTo(listeFigurines));
        }
    }

    [TestFixture]
    public class EntrepotFigurinesDictionnaireTest : EntrepotFigurineTest
    {
        [Test]
        public override void RetourneListeVideQuandPasDeFigurinesDansLEntrepot()
        {
            IEntrepotFigurines entrepotFigurines = new EntrepotDictionnaireFigurines();

            Assert.That(entrepotFigurines.ToutesFigurines(), Is.Empty);
        }

        [Test]
        public override void RetourneListeDeFigurinesContenuesDansLEntrepot()
        {
            var tintin = new Figurine("Tintin");
            var milou = new Figurine("Milou");
            var dictionary = new Dictionary<string, Figurine> { {tintin.Nom, tintin},
                                                                    {milou.Nom, milou}};
            IEntrepotFigurines entrepotFigurines = new EntrepotDictionnaireFigurines(dictionary);
            var listeFigurines = new List<Figurine> { tintin, milou };

            Assert.That(entrepotFigurines.ToutesFigurines(), Is.EqualTo(listeFigurines));
        }
    }
}
