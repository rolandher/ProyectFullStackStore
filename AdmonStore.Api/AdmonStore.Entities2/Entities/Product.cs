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
            public int Id_Store{ get; set; }            
            public string Names { get; set; }
            public string Description { get; set; }
            public int Stock { get; set; }
            public decimal Price { get; set; }
            public DateTime AdmissionDate { get; set; }
            public DateTime? DepartureDate { get; set; }
            public string State { get; set; }
        
    }
}
