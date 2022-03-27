using BigStoreCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigStoreCore.Interfaces
{
    public interface IMainBusinessLayer
    {
        Task<List<Product>> GetProducts();
        Task<List<Category>> GetCategories();
        Task<List<MenuDiscount>> GetMenuDiscounts();
        Task<List<Discount>> GetDiscounts();
    }
}
