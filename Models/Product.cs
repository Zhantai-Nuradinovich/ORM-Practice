using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
