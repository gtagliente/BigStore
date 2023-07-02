using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigStoreCore.Interface;
using BigStoreCore.Models;

namespace BigStoreCore.Logics
{
    public class MockBusinessLayer // : IMainBusinessLayer
    {
        public async Task<List<Product>> GetProducts()
        {
            return new List<Product>
            {
                new Product{
                Category = new Category{Description="Primi", IsRoot = true}
                ,Name = "Pasta al pesto"
                , Price = 125
                }
            };
        }

        public Task<List<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuDiscount>> GetMenuDiscounts()
        {
            throw new NotImplementedException();
        }

        public Task<List<Discount>> GetDiscounts()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
