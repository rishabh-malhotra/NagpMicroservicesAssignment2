﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Model
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int OrderAmount { get; set; }
        public string OrderDate { get; set; }
    }
}
