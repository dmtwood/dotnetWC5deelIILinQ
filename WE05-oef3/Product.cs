namespace WE05_oef3
{
    class Product
    {
        public string Naam { get; set; }
        public string ProductCode { get; set; }
        public decimal Prijs { get; set; }
        public string Categorie { get; set; }

        public override string ToString()
        {
            return $"Naam = {Naam}, ProductCode = {ProductCode}, Prijs = {Prijs}, Categorie = {Categorie}";
        }
    }
}
