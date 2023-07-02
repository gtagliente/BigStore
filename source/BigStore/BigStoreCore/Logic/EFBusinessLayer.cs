using BigStoreCore.Interface;
using BigStoreCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigStoreCore.Logics
{
    public class EFBusinessLayer : IMainBusinessLayer
    {
        public BigStoreContext _context;
        public EFBusinessLayer(BigStoreContext context)
        {
            _context = context;
        }
        public virtual async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();

        }

        public virtual async Task<List<Category>> GetCategories(bool getOnlyRoots = true)
        {
            return await _context.Categories.Where(c => getOnlyRoots ? c.IsRoot == true : true).ToListAsync();
        }

        public virtual async Task<List<MenuDiscount>> GetMenuDiscounts()
        {

            return await _context.MenuDiscounts.ToListAsync();
        }

        public virtual async Task<List<Discount>> GetDiscounts()
        {
            return await _context.Discounts.ToListAsync();
        }


        public virtual async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId, bool isRecursiveSearch)
        {
            IEnumerable<Product> products = new List<Product>();
            products = _context.Products.Where(p => p.CategoryId == categoryId).ToList();

            if (!isRecursiveSearch) return products;

            IEnumerable<int> subCategoriesIds = _context.CategoryHierarchies.Where(c => c.FatherCategory == categoryId).Select(c => c.ChildCategory).ToList();

            foreach (int subCategoryId in subCategoriesIds)
            {
                products = products.Concat(GetProductsByCategory(subCategoryId, isRecursiveSearch).Result);
            }

            return products;
        }

        public virtual async Task<IEnumerable<Category>> GetSubCategories(int categoryId, bool isRecursive = false)
        {
            //var subCategoriesH = _context.Categories
            //                    .Where(c => c.CategoryId == categoryId)
            //                    .Include(c => c.CategoryHierarchyFatherCategoryNavigations)
            //                    .Select(c => c.CategoryHierarchyFatherCategoryNavigations)
            //                    .FirstOrDefault();

            //IEnumerable<Category> subCategories = _context.CategoryHierarchies
            //                    .Include(c => c.ChildCategoryNavigation)
            //                    .Where(c => subCategoriesH.Select(ch => ch.ChildCategory).Contains(c.ChildCategory))
            //                    .Select(ch => ch.ChildCategoryNavigation);

            IEnumerable<Category> subCategories = _context.Categories
                .Join(_context.CategoryHierarchies.Where(ch => ch.FatherCategory == categoryId)
                , c => c.CategoryId
                , ch => ch.ChildCategory
                , (c, ch) => new { Category = c })
                   .Select(x => x.Category);  // select result


            if (!isRecursive) return subCategories;
            foreach (var subCategory in subCategories)
            {
                IEnumerable<Category> subCategoriesNextLev = GetSubCategories(subCategory.CategoryId,true).Result;
                subCategories = subCategories.Concat(subCategoriesNextLev);
            }
            return subCategories;
        }

        //private IEnumerable<Category> GetWithSubcategories(int categoryId)
        //{

        //}

        public void Dispose()
        {
            _context.Dispose();
            // GC.Collect();
        }
    }
}
