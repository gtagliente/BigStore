using System;
using System.Collections.Generic;

namespace BigStoreCore.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryHierarchyFatherCategoryNavigations = new HashSet<CategoryHierarchy>();
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; } = null!;
        public bool? IsRoot { get; set; }

        public virtual CategoryHierarchy CategoryHierarchyChildCategoryNavigation { get; set; } = null!;
        public virtual ICollection<CategoryHierarchy> CategoryHierarchyFatherCategoryNavigations { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
