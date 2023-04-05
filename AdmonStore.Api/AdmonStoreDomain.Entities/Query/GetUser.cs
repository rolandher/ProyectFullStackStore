using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStoreDomain.Entities.Query
{
    public class GetUser
    {
        public string Fire_Id { get; set; }
        public string Names { get; set; }
        public string SurNames { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }

    }
}
