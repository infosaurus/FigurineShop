using System;
using System.Collections.Generic;
using FigurineShop.Bornes;
using FigurineShop.Entites;
using FigurineShop.Interacteurs;
using Moq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace FigurineShop.Tests
{
    [TestFixture]
    public class TestInteracteurCatalogue
    {
        private Mock<IEntrepotFigurines> doublureEntrepot;
        private InteracteurCatalogueFigurines interacteur;

        [SetUp]
        public void SetUp()
        {
            doublureEntrepot = new Mock<IEntrepotFigurines>();
            interacteur = new InteracteurCatalogueFigurines(doublureEntrepot.Object);
        }

        [Test]
        public void InteracteurCommuniqueAvecEntrepotFigurines()
        {
            interacteur.Catalogue();

            doublureEntrepot.Verify(d => d.ToutesFigurines(), Times.Exactly(1));
        }

        [Test]
        public void InteracteurRetourneReponseVideSiEntrepotVide()
        {
            doublureEntrepot.Setup(d => d.ToutesFigurines()).Returns(new List<Figurine>());

            Assert.That(interacteur.Catalogue(), Is.Empty);
        }

        [Test]
        public void InteracteurPeutRetournerListeFigurinesContenueDansEntrepot()
        {
            var listeFigurines = new List<Figurine>
                                     {
                                         new Figurine("Tintin"),
                                         new Figurine("Milou"),
                                         new Figurine("Capitaine Haddock")
                                     };
            doublureEntrepot.Setup(d => d.ToutesFigurines()).Returns(listeFigurines);

            Assert.AreEqual(listeFigurines, interacteur.Catalogue());
        }
    }

    [TestFixture]
    public class TestInteracteurAjoutFigurinePanier
    {
        private Mock<IPanierFigurines> panier;
        private InteracteurAjoutFigurinePanier interacteur;

        [SetUp]
        public void SetUp()
        {
            this.panier = new Mock<IPanierFigurines>();
            this.interacteur = new InteracteurAjoutFigurinePanier(panier.Object);
        }

        [Test]
        public void InteracteurNAjoutePasUneFigurineNulle()
        {
            interacteur.AjouterFigurine(null);

            panier.Verify(p => p.AjouterFigurine(It.IsAny<Figurine>()), Times.Never());
        }

        [Test]
        public void InteracteurPeutAjouterFigurineAuPanier()
        {
            var figurine = new Figurine("Tintin");

            interacteur.AjouterFigurine(figurine);

            panier.Verify(p => p.AjouterFigurine(figurine));
        }
    }

    [TestFixture]
    public class TestInteracteurConsultationPanier
    {
        private Mock<IPanierFigurines> panier;
        private InteracteurConsultationPanier interacteur;

        [SetUp]
        public void SetUp()
        {
            this.panier = new Mock<IPanierFigurines>();
            this.interacteur = new InteracteurConsultationPanier(panier.Object);
        }

        [Test]
        public void InteracteurCommuniqueAvecPanier()
        {
            interacteur.ConsulterPanier();

            panier.Verify(p => p.Figurines, Times.Once());
            panier.Verify(p => p.CalculeTotal(), Times.Once());
        }

        [Test]
        public void InteracteurRetourneRéponseAvecListeVideQuandFigurinesNull()
        {
            panier.Setup(p => p.Figurines).Returns(() => null);

            Assert.AreEqual(new Dictionary<Figurine, int>(), interacteur.ConsulterPanier().Figurines);
        }

        [Test]
        public void InteracteurPeutRetournerTroisFigurines()
        {
            var figurines = new Dictionary<Figurine, int>
                                {
                                    {new Figurine("Tintin"), 1},
                                    {new Figurine("Milou"), 1},
                                    {new Figurine("Capitaine Haddock"), 1},
                                };
            panier.Setup(p => p.Figurines).Returns(figurines);

            Assert.AreEqual(figurines, interacteur.ConsulterPanier().Figurines);
        }

        [Test]
        public void InteracteurRetourneLeBonMontant()
        {
            var montantTotal = 10f;
            panier.Setup(p => p.CalculeTotal()).Returns(montantTotal);

            Assert.AreEqual(montantTotal, interacteur.ConsulterPanier().Montant);
        }
    }
}
