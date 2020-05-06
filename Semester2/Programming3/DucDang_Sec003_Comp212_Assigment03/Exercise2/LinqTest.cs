using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise2
{
    public class LinqTest
    {
        public static void Main(string[] args)
        {
            // initialize array of invoices
            Invoice[] invoices = {
                new Invoice( 83, "Electric sander", 7, 57.98M ),
                new Invoice( 24, "Power saw", 18, 99.99M ),
                new Invoice( 7, "Sledge hammer", 11, 21.5M ),
                new Invoice( 77, "Hammer", 76, 11.99M ),
                new Invoice( 39, "Lawn mower", 3, 79.5M ),
                new Invoice( 68, "Screwdriver", 106, 6.99M ),
                new Invoice( 56, "Jig saw", 21, 11M ),
                new Invoice( 3, "Wrench", 34, 7.5M ) };

            //display all invoices
            Console.WriteLine("Original array:");
            foreach (var item in invoices)
                Console.WriteLine(item);

            //b) Use LINQ to sort the Invoice objects by Price.
            var priceSort =
                from i in invoices
                orderby i.Price
                select i;

            //header
            Console.WriteLine("\nInvoices when sorted by price");

            // attempt to display the results of the above LINQ query
            if (priceSort.Any())
                foreach (var item in priceSort)
                    Console.WriteLine(item);
            else
                Console.WriteLine("not found");

            //c) Use LINQ to select the PartDescription and Quantity and sort the results by Quantity.
            var sortQuantityandOnlyDescandQuantity =
                from i in invoices
                orderby i.Quantity
                select new { i.PartDescription, i.Quantity };

            //header
            Console.WriteLine("\nInvoices Average pirce of the parts");
            decimal average = 0;
            foreach (var item in priceSort)
            {

                average += item.Price;
            }
                Console.WriteLine(average/8);
        }
    }
}
