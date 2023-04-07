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

        public Location() { }

        public static void Validate(Location location)
        {
            if (location.Id_Store == 0 || location.Id_Store == null)
            {
                throw new Exception("The store doesn't exist.");
            }

            if (string.IsNullOrEmpty(location.Names))
            {
                throw new Exception("The name is required.");
            }

            if (string.IsNullOrEmpty(location.Description))
            {
                throw new Exception("The description is required.");
            }

            if (string.IsNullOrEmpty(location.Location_Type))
            {
                throw new Exception("The location type is required.");
            }
        }
    }
}
