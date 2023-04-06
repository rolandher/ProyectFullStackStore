using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Entities2.Commands
{
    public class NewLocation
    {
        public int Id_Store { get; set; }
        public string Names { get; set; } 
        public string Description { get; set; }
        public string Location_Type { get; set; } 
    }
}
