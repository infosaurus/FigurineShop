using System.Collections.Generic;
using FigurineShop.Entites;
using FigurineShop.Interacteurs;
using FigurineShop.UI;
using Moq;
using NUnit.Framework;

namespace FigurineShop.Tests
{
    [TestFixture]
    public class PresenteurCatalogueTest
    {
        [Test]
        public void PresenteurCommuniqueAvecInteracteurCatalogue()
        {
            var interacteur = new Mock<IInteracteurCatalogue>();
            var presenteur = new PresenteurCatalogue(interacteur.Object);

            presenteur.Catalogue();

            interacteur.Verify(i => i.Catalogue(), Times.Once());
        }

        [Test]
        public void PresenteurRetourneCatalogueQueLuiADonnéInteracteur()
        {
            var interacteur = new Mock<IInteracteurCatalogue>();
            var presenteur = new PresenteurCatalogue(interacteur.Object);

            var figurines = new List<Figurine> { new Figurine("Tintin"), new Figurine("Milou"), new Figurine("Haddock") };
            interacteur.Setup(i => i.Catalogue()).Returns(figurines);

            Assert.AreEqual(figurines, presenteur.Catalogue());
        }
    }

    [TestFixture]
    public class PresenteurAjoutFigurineTest
    {
        [Test]
        public void PresenteurAjoutFigurineAppelleInteracteur()
        {
            var interacteur = new Mock<IInteracteurAjoutFigurine>();
            var presenteur = new PresenteurAjoutFigurine(interacteur.Object);

            var figurine = new Figurine("Tintin");
            presenteur.AjouterFigurine(figurine);

            interacteur.Verify(i => i.AjouterFigurine(figurine), Times.Once());
        }
    }

    [TestFixture]
    public class PresenteurPanierTest
    {
        [Test]
        public void PresenteurAppelleInteracteurPanier()
        {
            var interacteur = new Mock<IInteracteurConsultationPanier>();
            var presenteur = new PresenteurPanier(interacteur.Object);

            presenteur.Update();

            interacteur.Verify(i => i.ConsulterPanier(), Times.Once());
        }

        [Test]
        public void PresenteurContientLesBonnesDonnées()
        {
            var interacteur = new Mock<IInteracteurConsultationPanier>();
            var lignesPanier = new Dictionary<Figurine, int>()
                                   {
                                       {new Figurine("Tintin"), 1},
                                       {new Figurine("Milou"), 2}
                                   };
            var total = 32f;
            var reponse = new ModeleReponsePanier(lignesPanier, total);
            interacteur.Setup(i => i.ConsulterPanier()).Returns(reponse);
            var presenteur = new PresenteurPanier(interacteur.Object);

            presenteur.Update();

            Assert.AreEqual(lignesPanier, presenteur.LignesPanier);
            Assert.AreEqual(total, presenteur.MontantPanier);
        }
    }
}
