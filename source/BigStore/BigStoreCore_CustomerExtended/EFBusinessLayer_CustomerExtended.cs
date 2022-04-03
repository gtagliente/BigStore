using BigStoreCore.Interfaces;
using BigStoreCore.Logic;
using BigStoreCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BigStoreCore_CustomerExtended
{
    public class EFBusinessLayer_CustomerExtended : EFBusinessLayer
    {
        public BigStoreContext _context;
        public EFBusinessLayer_CustomerExtended(BigStoreContext context): base(context)
        {
        }

        public override async Task<List<Product>> GetProducts()
        {
            List<Product> prod_ext = await base.GetProducts();
            return prod_ext.Where(p => p.ProductId%2 ==0).ToList();
        }
    }
}