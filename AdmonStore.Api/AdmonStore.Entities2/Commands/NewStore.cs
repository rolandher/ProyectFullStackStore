using AdmonStore.Entities2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Entities2.Commands
{
    public class NewStore
    {
        [Required(ErrorMessage = "Id_User is required")]
        public string Id_User { get; set; }

        [Required(ErrorMessage = "Names is required")]
        public string Names { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
