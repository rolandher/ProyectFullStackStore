using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Entities2.Commands
{
    public class NewProduct
    {
        [Required(ErrorMessage = "Id_Store is required")]
        public int Id_Store { get; set; }
        [Required(ErrorMessage = "Names is required")]
        public string Names { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Stock is required")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "AdmissionDate is required")]
        public DateTime AdmissionDate { get; set; }        
        public DateTime? DepartureDate { get; set; }
        [Required(ErrorMessage = "State is required")]
        public bool State { get; set; }
    }
}
