using System;
using System.Collections.Generic;

namespace BigStoreCore.Models
{
    public partial class Discount
    {
        public int DiscountId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int DiscountPercentage { get; set; }
        public bool? Enabled { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
