using System;
using System.Collections.Generic;
using System.Linq;

namespace WE05_oef3
{
    class Program
    {
        static void Main(string[] args)
        {
            var producten = new List<Product> {
                new Product{Naam= "Playstation 4", ProductCode="PS4", Prijs = 399.9M, Categorie = "GAMES"},
                new Product{Naam= "XBOX ONE", ProductCode="XB1", Prijs = 500M, Categorie = "GAMES"},
                new Product{Naam= "The Last of Us II", ProductCode="LAST2", Prijs = 60M, Categorie = "GAMES"},
                new Product{Naam= "SONY Bravia 4K", ProductCode="SB_4K", Prijs = 4000M, Categorie = "TV"},
                new Product{Naam= "SONY Bravia V273", ProductCode="SB_V273", Prijs = 400M, Categorie = "TV"},
            };

            MethodSyntax(producten);
            QuerySyntax(producten);
        }

        private static void MethodSyntax(List<Product> producten)
        {
            Console.WriteLine(producten.OrderByDescending(p => p.Prijs).First());
            Console.WriteLine(producten.Average(p => p.Prijs));

            var categoryGroups = producten.GroupBy(p => p.Categorie);

            foreach (var group in categoryGroups)
            {
                Console.WriteLine(group.Key);
                Console.WriteLine("Aantal: {0}", group.Count());
                Console.WriteLine("Duurste: {0}", group.OrderByDescending(p => p.Prijs).First().Naam);
                Console.WriteLine("Goedkoopste: {0}", group.OrderBy(p => p.Prijs).First().Naam);
                Console.WriteLine("Gemiddele prijs: {0}", Math.Round(group.Average(p => p.Prijs), 2));
                Console.WriteLine();
            }


            /* Alternatieve oplossing voor group by met select in anoniem type */
            var anonGroups =
                producten.GroupBy(p => p.Categorie)
                .Select(group => new
                {
                    CatNaam = group.Key,
                    Aantal = group.Count(),
                    Duurste = group.OrderByDescending(p => p.Prijs).First().Naam,
                    Goedkoopste = group.OrderBy(p => p.Prijs).First().Naam,
                    GemPrijs = group.Average(p => p.Prijs)
                });

            foreach (var anon in anonGroups)
            {
                Console.WriteLine(anon.CatNaam);
                Console.WriteLine("Aantal: {0}", anon.Aantal);
                Console.WriteLine("Duurste: {0}", anon.Duurste);
                Console.WriteLine("Goedkoopste: {0}", anon.Goedkoopste);
                Console.WriteLine("Gemiddele prijs: {0}", Math.Round(anon.GemPrijs, 2));
                Console.WriteLine();
            }

        }

        private static void QuerySyntax(List<Product> producten)
        {
            var duurste = (from p in producten
                           where p.Prijs == (from prod in producten orderby prod.Prijs descending select p.Prijs).Max()
                           select p).First();

            var gem = (from p in producten
                       select p.Prijs).Average();

            var categories = from p in producten
                             group p by p.Categorie;

            foreach (var cat in categories)
            {
                Console.WriteLine(cat.Key);
                Console.WriteLine("Aantal: {0}", cat.Count());
                Console.WriteLine("Duurste: {0}", (from p in cat orderby p.Prijs descending select p).First().Naam);
                Console.WriteLine("Goedkoopste: {0}", (from p in cat orderby p.Prijs select p).First().Naam);
                Console.WriteLine("Gemiddele prijs: {0}", Math.Round((from p in cat select p.Prijs).Average(), 2));
                Console.WriteLine();
            }

            /* Alternatieve oplossing voor group by met select in anoniem type */
            var anonGroups = from p in producten
                             group p by p.Categorie into cat
                             select new
                             {
                                 CatNaam = cat.Key,
                                 Aantal = cat.Count(),
                                 Duurste = (from p in cat orderby p.Prijs descending select p).First().Naam,
                                 Goedkoopste = (from p in cat orderby p.Prijs select p).First().Naam,
                                 GemPrijs = (from p in cat select p.Prijs).Average()
                             };

            foreach (var anon in anonGroups)
            {
                Console.WriteLine(anon.CatNaam);
                Console.WriteLine("Aantal: {0}", anon.Aantal);
                Console.WriteLine("Duurste: {0}", anon.Duurste);
                Console.WriteLine("Goedkoopste: {0}", anon.Goedkoopste);
                Console.WriteLine("Gemiddele prijs: {0}", Math.Round(anon.GemPrijs, 2));
                Console.WriteLine();
            }
        }
    }
}
