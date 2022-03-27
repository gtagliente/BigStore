using System;
using System.Collections.Generic;

namespace BigStoreCore.Models
{
    public partial class Product
    {
        public Product()
        {
            Discounts = new HashSet<Discount>();
            POrders = new HashSet<POrder>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Details { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<POrder> POrders { get; set; }
    }
}
