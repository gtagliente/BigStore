using System;
using System.Collections.Generic;

namespace BigStoreCore.Models
{
    public partial class CategoryHierarchy
    {
        public int Id { get; set; }
        public int FatherCategory { get; set; }
        public int ChildCategory { get; set; }

        public virtual Category ChildCategoryNavigation { get; set; } = null!;
        public virtual Category FatherCategoryNavigation { get; set; } = null!;
    }
}
