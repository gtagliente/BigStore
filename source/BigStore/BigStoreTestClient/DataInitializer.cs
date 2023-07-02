using BigStoreCore.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigStoreTestClient
{
    public class DataInitializer
    {
        // private BigStoreContext _moqContext;
        //private  DbSet<Product> _products;
        public static List<Product> GetAllProducts()
        {
            var products = new List<Product> {
        new Product() {
           ProductId = 1
         , Name = "Spaghetti",
           Price = 10
        },
        new Product() {
          ProductId = 2
         , Name = "Pennette",
           Price = 8
        },
        new Product() {
           ProductId = 3
         , Name = "Ravioli",
           Price = 8
        }
      };
            return products;
        }
        public static BigStoreContext SetUpDBContext()
        {
            var context = new Mock<BigStoreContext>();
            context.SetupGet(s => s.Products).Returns(GetQueryableMockDbSet(new List<Product>()));
            context.SetupGet(s => s.Categories).Returns(GetQueryableMockDbSet(new List<Category>()));
            context.SetupGet(s => s.CategoryHierarchies).Returns(GetQueryableMockDbSet(new List<CategoryHierarchy>()));
            //_moqContext = context.Object;
            return context.Object;
        }
        //private DbSet<Product> SetUpProductRepository()
        //{

        //    // Initialise repository  
        //    _products = DataInitializer.GetQueryableMockDbSet<Product>(new List<Product>());
        //    return _products;

        //}

        public static List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category { CategoryId = 1, Description = "Pranzo", IsRoot = true });
            categories.Add(new Category { CategoryId = 2, Description = "Primi Piatti", IsRoot = false });
            categories.Add(new Category { CategoryId = 3, Description = "Secondi", IsRoot = false });
            categories.Add(new Category { CategoryId = 4, Description = "Primi di mare", IsRoot = false });
            categories.Add(new Category { CategoryId = 5, Description = "Primo del giorno", IsRoot = false });
            return categories;
        }
        public static List<CategoryHierarchy> CreateRecuriveCategoryStructure()
        {
            List<CategoryHierarchy> categoriesHierarcy = new List<CategoryHierarchy>();
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 2, FatherCategory = 1 });
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 3, FatherCategory = 1 });
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 4, FatherCategory = 2 });
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 5, FatherCategory = 4 });
            return categoriesHierarcy;
        }



        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }
    }
}
