using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Product
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
