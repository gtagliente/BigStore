using BigStoreCore.Interfaces;
using BigStoreCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigStoreCore.Logic
{
    public class EFBusinessLayer : IMainBusinessLayer
    {
        public async  Task<List<Product>> GetProducts()
        {

            using(BigStoreContext ctx  = new BigStoreContext())  {
                return await ctx.Products.ToListAsync();
            }
        }

        public async Task<List<Category>> GetCategories()
        {
            using (BigStoreContext ctx = new BigStoreContext())
            {
                return await ctx.Categories.ToListAsync();
            }
        }

        public async Task<List<MenuDiscount>> GetMenuDiscounts()
        {
            using (BigStoreContext ctx = new BigStoreContext())
            {
                return await ctx.MenuDiscounts.ToListAsync();
            }
        }

        public async Task<List<Discount>> GetDiscounts()
        {
            using (BigStoreContext ctx = new BigStoreContext())
            {
                return await ctx.Discounts.ToListAsync();
            }
        }
    }
}
