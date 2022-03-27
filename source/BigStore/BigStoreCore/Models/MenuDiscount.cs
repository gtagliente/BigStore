using System;
using System.Collections.Generic;

namespace BigStoreCore.Models
{
    public partial class MenuDiscount
    {
        public MenuDiscount()
        {
            POrders = new HashSet<POrder>();
        }

        public int MenuId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int DiscountPercentage { get; set; }
        public bool? Enabled { get; set; }

        public virtual ICollection<POrder> POrders { get; set; }
    }
}
