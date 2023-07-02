using Microsoft.AspNetCore.Mvc;
using BigStoreCore.Interface;
using BigStoreCore.Models;

namespace BigStoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BigStoreController : Controller
    {
        public readonly IMainBusinessLayer _layer;

        public BigStoreController(IMainBusinessLayer layer)
        {
            _layer = layer;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet,Route("Products")]
        public async Task<List<Product>> GetProducts()
        {
            return await _layer.GetProducts();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet,Route("Categories")]
        public async Task<List<Category>> GetCategories()
        {
            return (await _layer.GetCategories());
        }
    }
}
