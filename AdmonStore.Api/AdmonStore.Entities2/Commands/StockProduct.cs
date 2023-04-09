﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Entities2.Commands
{
    public class StockProduct
    {
        [Required(ErrorMessage = "Id is required")]
        public int Product_Id { get; set; }
        [Required(ErrorMessage = "Stock is required")]
        public int Stock { get; set; }        
    }
}