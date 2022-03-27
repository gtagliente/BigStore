using System;
using System.Collections.Generic;

namespace BigStoreCore.Models
{
    public partial class POrder
    {
        public int OrderId { get; set; }
        public int ProductOrMenu { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? OrderState { get; set; }
        public bool IsMenu { get; set; }

        public virtual Product ProductOrMenu1 { get; set; } = null!;
        public virtual MenuDiscount ProductOrMenuNavigation { get; set; } = null!;
    }
}
