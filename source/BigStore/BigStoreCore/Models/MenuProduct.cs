using System;
using System.Collections.Generic;

namespace BigStoreCore.Models
{
    public partial class MenuProduct
    {
        public int ProductId { get; set; }
        public int MenuId { get; set; }

        public virtual MenuDiscount Menu { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
