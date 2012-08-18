using System.Collections.Generic;
using FigurineShop.Entites;
using FigurineShop.Interacteurs;

namespace FigurineShop.UI
{
    public class PresenteurPanier
    {
        private readonly IInteracteurConsultationPanier interacteurConsultationPanier;

        public PresenteurPanier(IInteracteurConsultationPanier interacteurConsultationPanier)
        {
            this.interacteurConsultationPanier = interacteurConsultationPanier;
        }

        public IDictionary<Figurine, int> LignesPanier
        {
            get;
            set;
        }

        public float MontantPanier { get; set; }

        public void Update()
        {
            var reponsePanier = interacteurConsultationPanier.ConsulterPanier();
            if (reponsePanier != null)
            {
                LignesPanier = reponsePanier.Figurines;
                MontantPanier = reponsePanier.Montant;
            }
        }
    }
}