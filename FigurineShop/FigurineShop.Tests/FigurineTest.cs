using FigurineShop.Entites;
using NUnit.Framework;

namespace FigurineShop.Tests
{
    [TestFixture]
    public class FigurineTest
    {
        [Test]
        public void PeutCreerFigurine()
        {
            var nom = "Tintin";
            var figurine = new Figurine(nom);

            Assert.AreEqual(nom, figurine.Nom);
        }
    }
}
