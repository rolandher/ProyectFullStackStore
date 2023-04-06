using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Entities2.Entities
{
    public class Location
    {
        public int Location_Id { get; set; }
        public int Id_Store { get; set; }
        public string Names { get; set; } //estante 1, pasillo 2
        public string Description { get; set; }
        public string Location_Type { get; set; } //estante", "pasillo", "sección
    }
}
