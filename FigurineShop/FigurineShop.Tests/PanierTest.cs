using FigurineShop.Entites;
using NUnit.Framework;

namespace FigurineShop.Tests
{
    [TestFixture]
    public class PanierTest
    {
        private PanierFigurines panier;

        [SetUp]
        public void TestSetUp()
        {
            panier = new PanierFigurines();
        }

        private void Ajouter(int nbFigurinesIdentiques, string nom)
        {
            var figurine = new Figurine(nom);
            for (int i = 0; i < nbFigurinesIdentiques; i++)
                panier.AjouterFigurine(figurine);
        }

        [Test]
        public void PanierVideCOuteZéroEuros()
        {
            Assert.AreEqual(0, panier.CalculeTotal());
        }

        [Test]
        public void UneFigurineCouteHuitEuros()
        {
            var figurine = new Figurine("Milou");
            panier.AjouterFigurine(figurine);

            Assert.AreEqual(PanierFigurines.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }

        [Test]
        public void DeuxFigurinesDifférentesOntRéduction5Pct()
        {
            panier.AjouterFigurine(new Figurine("Milou"));
            panier.AjouterFigurine(new Figurine("Tintin"));

            Assert.AreEqual(PanierFigurines.PRIX_UNITAIRE_FIGURINE * 2 * 0.95f, panier.CalculeTotal());
        }
        
        [Test]
        public void TroisFigurinesDifférentesOntRéduction10Pct()
        {
            panier.AjouterFigurine(new Figurine("Milou"));
            panier.AjouterFigurine(new Figurine("Tintin"));
            panier.AjouterFigurine(new Figurine("Capitaine Haddock"));

            Assert.AreEqual(PanierFigurines.PRIX_UNITAIRE_FIGURINE * 3 * 0.90f, panier.CalculeTotal());
        }
        
        [Test]
        public void QuatreFigurinesDifférentesOntRéduction25Pct()
        {
            panier.AjouterFigurine(new Figurine("Milou"));
            panier.AjouterFigurine(new Figurine("Tintin"));
            panier.AjouterFigurine(new Figurine("Capitaine Haddock"));
            panier.AjouterFigurine(new Figurine("Les Dupondt"));

            Assert.AreEqual(PanierFigurines.PRIX_UNITAIRE_FIGURINE * 4 * 0.75f, panier.CalculeTotal());
        }

        [Test]
        public void DeuxFigurinesIdentiquesNOntPasDeRéduction()
        {
            Ajouter(2, "Tintin");

            Assert.AreEqual(2 * PanierFigurines.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }

        [Test]
        public void TroisFigurinesIdentiquesNOntPasDeRéduction()
        {
            Ajouter(3, "Tintin");

            Assert.AreEqual(3 * PanierFigurines.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }

        [Test]
        public void DeuxFigurinesIdentiquesEtUneDifférenteOntRéduction5Pct()
        {
            Ajouter(2, "Tintin");
            Ajouter(1, "Milou");

            Assert.AreEqual(2 * PanierFigurines.PRIX_UNITAIRE_FIGURINE * 0.95f
                            + PanierFigurines.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }

        [Test]
        public void DeuxFigurinesIdentiquesEtDeuxDifférentesOntRéduction10Pct()
        {
            Ajouter(2, "Tintin");
            Ajouter(1, "Milou");
            Ajouter(1, "Capitaine Haddock");

            Assert.AreEqual(3 * PanierFigurines.PRIX_UNITAIRE_FIGURINE * 0.90f
                            + PanierFigurines.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }

        [Test]
        public void PanierAvecFigurinesAABBDonne5PctRéduction()
        {
            Ajouter(2, "Tintin");
            Ajouter(2, "Milou");

            Assert.AreEqual(4 * 0.95f * PanierFigurines.PRIX_UNITAIRE_FIGURINE, panier.CalculeTotal());
        }

        [Test]
        public void PanierAvecFigurinesAABBCDonne10PctPlus5PctRéduction()
        {
            Ajouter(2, "Tintin");
            Ajouter(2, "Milou");
            Ajouter(1, "Capitaine Haddock");

            Assert.AreEqual(2 * 0.95f * PanierFigurines.PRIX_UNITAIRE_FIGURINE
                            + 3 * 0.90f * PanierFigurines.PRIX_UNITAIRE_FIGURINE,
                            panier.CalculeTotal());
        }

        [Test]
        public void PanierAvecFigurinesAAABBBCDonne10PctPlus5PctPlus5PctRéduction()
        {
            Ajouter(3, "Tintin");
            Ajouter(3, "Milou");
            Ajouter(1, "Capitaine Haddock");

            Assert.AreEqual(4 * 0.95f * PanierFigurines.PRIX_UNITAIRE_FIGURINE
                            + 3 * 0.90f * PanierFigurines.PRIX_UNITAIRE_FIGURINE,
                            panier.CalculeTotal());
        }

        [Test]
        public void AjouterUneFigurineDonneQuantitéDeUn()
        {
            var figurine = new Figurine("Milou");
            panier.AjouterFigurine(figurine);

            Assert.AreEqual(1, panier.Figurines[figurine]);
        }

        [Test]
        public void AjouterDeuxFigurinesDonneQuantitéDeDeux()
        {
            var figurine = new Figurine("Milou");
            panier.AjouterFigurine(figurine);
            panier.AjouterFigurine(figurine);

            Assert.AreEqual(2, panier.Figurines[figurine]);
        }

    }
}