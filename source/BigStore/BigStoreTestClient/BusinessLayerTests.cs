using BigStoreCore.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using BigStoreCore.Logics;

namespace BigStoreTestClient
{
    [TestFixture]
    internal class BusinessLayerTests
    {
        private BigStoreContext _ctx;
        private EFBusinessLayer _logic;
        [SetUp]
        public void SetUpt()
        {
            _ctx = DataInitializer.SetUpDBContext();
            _logic = new EFBusinessLayer(_ctx);
        }

        //[Test]
        //public void TestGetProducts()
        //{
        //    Assert.AreEqual(_ctx.Products.Count(), 3);
        //}

        [Test]
        public void AddProducts()
        {
            int nProducts = _ctx.Products.Count();
            _ctx.Products.Add(new Product { ProductId = 4, Name = "Melon Ice cream" });
            Assert.AreEqual(nProducts+1, _ctx.Products.Count());
        }

        [TestCase(1,4,true)]
        [TestCase(2, 2, true)]
        [TestCase(4, 1, true)]
        [TestCase(5, 0, true)]
        [TestCase(44, 0, true)]
        public void GetCategoriesRecursive(int categoryId,int ExpectedCategories, bool isRecursive)
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category { CategoryId = 1, Description = "Pranzo", IsRoot = true });
            categories.Add(new Category { CategoryId = 2, Description = "Primi Piatti", IsRoot = false });
            categories.Add(new Category { CategoryId = 3, Description = "Secondi", IsRoot = false });
            categories.Add(new Category { CategoryId = 4, Description = "Primi di mare", IsRoot = false });
            categories.Add(new Category { CategoryId = 5, Description = "Primo del giorno", IsRoot = false });
            foreach (var category in categories)
                _ctx.Categories.Add(category);

            List<CategoryHierarchy> categoriesHierarcy = new List<CategoryHierarchy>();
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 2, FatherCategory = 1 });
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 3, FatherCategory = 1 });
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 4, FatherCategory = 2 });
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 5, FatherCategory = 4 });
            foreach (var categoryHierarcy in categoriesHierarcy)
                _ctx.CategoryHierarchies.Add(categoryHierarcy);

            IEnumerable<Category> lstCategory = _logic.GetSubCategories(categoryId, isRecursive).Result;

            Assert.AreEqual(ExpectedCategories, lstCategory.Count());
        }


        [TestCase(1, 6,true)]
        [TestCase(1, 0, false)]
        [TestCase(2, 6,true)]
        [TestCase(2, 2, false)]
        [TestCase(5, 2,true)]
        [TestCase(5, 2, false)]
        public void GetProducts(int categoryId, int ExpectedCategories,bool isRecursive)
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category { CategoryId = 1, Description = "Pranzo", IsRoot = true });
            categories.Add(new Category { CategoryId = 2, Description = "Primi Piatti", IsRoot = false });
            categories.Add(new Category { CategoryId = 3, Description = "Secondi", IsRoot = false });
            categories.Add(new Category { CategoryId = 4, Description = "Primi di mare", IsRoot = false });
            categories.Add(new Category { CategoryId = 5, Description = "Primi del giorno", IsRoot = false });
            foreach (var category in categories)
                _ctx.Categories.Add(category);

            List<CategoryHierarchy> categoriesHierarcy = new List<CategoryHierarchy>();
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 2, FatherCategory = 1 });
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 3, FatherCategory = 1 });
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 4, FatherCategory = 2 });
            categoriesHierarcy.Add(new CategoryHierarchy { ChildCategory = 5, FatherCategory = 4 });
            foreach (var categoryHierarcy in categoriesHierarcy)
                _ctx.CategoryHierarchies.Add(categoryHierarcy);

            List<Product> products = new List<Product>();
            products.Add(new Product { CategoryId = 2, Name = "Spaghetti" });
            products.Add(new Product { CategoryId = 2, Name = "Carbonara" });
            products.Add(new Product { CategoryId = 4, Name = "Spaghetti alle vongole" });
            products.Add(new Product { CategoryId = 4, Name = "riso" });
            products.Add(new Product { CategoryId = 5, Name = "Penne allo scoglio" });
            products.Add(new Product { CategoryId = 5, Name = "risotto ai gamberi" });
            foreach (var product in products)
                _ctx.Products.Add(product);

            IEnumerable<Product> lstProducts = _logic.GetProductsByCategory(categoryId,isRecursive).Result;

            Assert.AreEqual(ExpectedCategories, lstProducts.Count());
        }
    }
}
