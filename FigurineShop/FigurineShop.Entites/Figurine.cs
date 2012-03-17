namespace FigurineShop.Entites
{
    public class Figurine
    {
        private string nom;

        public Figurine(string nom)
        {
            this.nom = nom;       
        }

        public string Nom
        {
            get {
                return nom;
            }
        }
    }
}