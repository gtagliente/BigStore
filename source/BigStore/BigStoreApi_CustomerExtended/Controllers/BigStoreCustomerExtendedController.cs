using BigStoreApi.Controllers;
using BigStoreCore.Interface;
using BigStoreCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BigStoreApi_Extended.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BigStoreCustomerExtendedController : BigStoreController
    {
        private readonly ILogger<BigStoreCustomerExtendedController> _logger;
        public BigStoreCustomerExtendedController(IMainBusinessLayer layer, ILogger<BigStoreCustomerExtendedController> logger) : base(layer)
        {
            _logger = logger;
        }

        [HttpGet, Route("GetProducts")]
        public async Task<List<Product>> GetProductsExt()
        {
            return await GetProducts();
        }

        [HttpGet, Route("GetCategories")]
        public async Task<List<Category>> GetCategories()
        {
            return await base.GetCategories();
        }

        [HttpGet, Route("GetWithSubCategories")]
        public async Task<IEnumerable<Category>> GetWithSubCategoriesRecursive(int categoryId)
        {
            _logger.LogInformation($"Getting subcategories for Id: {categoryId}");
            IEnumerable<Category> lst = await _layer.GetSubCategories(categoryId);
            _logger.LogInformation($"Categories found: { JsonSerializer.Serialize(lst)}");
            return lst;
        }
    }
}
