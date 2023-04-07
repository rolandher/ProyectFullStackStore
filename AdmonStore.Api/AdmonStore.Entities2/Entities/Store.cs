using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Entities2.Entities
{
    public class Store
    {
        public int Store_Id { get; set; }
        public string Id_User { get; set; }
        public string Names { get; set; }
        public string Description { get; set; }

        public Store() { }

        public static void Validate(Store store)
        {
            if (string.IsNullOrEmpty(store.Id_User))
            {
                throw new Exception("The user is required.");
            }

            if (string.IsNullOrEmpty(store.Names))
            {
                throw new Exception("The name is required.");
            }

            if (string.IsNullOrEmpty(store.Description))
            {
                throw new Exception("The description is required.");
            }
        }
    }
}
