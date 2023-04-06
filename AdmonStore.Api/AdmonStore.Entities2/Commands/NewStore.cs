using AdmonStore.Entities2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Entities2.Commands
{
    public class NewStore
    {
        public string Id_User { get; set; }
        public string Names { get; set; }
        public string Description { get; set; }
    }
}
