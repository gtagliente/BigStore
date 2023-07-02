using BigStoreCore.Interface;
using BigStoreCore.Logics;
using BigStoreCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BigStoreCore_CustomerExtended
{
    public class EFBusinessLayer_CustomerExtended : EFBusinessLayer
    {
        public EFBusinessLayer_CustomerExtended(BigStoreContext context): base(context)
        {
        }
        public override async Task<List<Product>> GetProducts()
        {
            List<Product> prod_ext = await base._context.Products.Include(p => p.Category).ToListAsync();
            prod_ext.ForEach(p => { p.Category.Products = null;p.Category.CategoryHierarchyFatherCategoryNavigations = null; p.Category.CategoryHierarchyChildCategoryNavigation = null; }) ;
            return prod_ext;    
        }
    }
}