using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Entities2.Entities
{
    public class Product
    {
        public int Product_Id { get; set; }
        public int Id_Store { get; set; }
        public string Names { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public bool State { get; set; }

        public Product() { }

        public static void Validate(Product product)
        {
            if (product.Id_Store == 0 || product.Id_Store == null)
            {
                throw new Exception("The store doesn't exist.");
            }

            if (string.IsNullOrEmpty(product.Names))
            {
                throw new Exception("The name is required.");
            }

            if (string.IsNullOrEmpty(product.Description))
            {
                throw new Exception("The description is required.");
            }

            if (product.Stock == 0 || product.Stock == null)
            {
                throw new Exception("The stock is required.");
            }

            if (product.Price == 0 || product.Price == null)
            {
                throw new Exception("The price is required.");
            }

            if (product.AdmissionDate == null)
            {
                throw new Exception("The admission date is required.");
            }
            if (product.State == null)
            {
                throw new Exception("The state is required.");
            }            

        }

    }
}
