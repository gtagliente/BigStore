using BigStoreCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigStoreCore.Interface
{
    public interface IMainBusinessLayer: IDisposable
    {
        Task<List<Product>> GetProducts();
        Task<List<Category>> GetCategories(bool getOnlyRoots=true);
        Task<List<MenuDiscount>> GetMenuDiscounts();
        Task<List<Discount>> GetDiscounts();
        Task<IEnumerable<Category>> GetSubCategories(int v, bool isRecursive = false);
    }
}
