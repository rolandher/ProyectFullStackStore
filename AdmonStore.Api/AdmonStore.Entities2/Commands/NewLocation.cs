using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Entities2.Commands
{
    public class NewLocation
    {
        [Required(ErrorMessage = "Id_Store is required")]
        public int Id_Store { get; set; }
        [Required(ErrorMessage = "Names is required")]
        public string Names { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Location_Type is required")]
        public string Location_Type { get; set; } 
    }
}
