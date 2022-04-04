using Microsoft.AspNetCore.Mvc;
using BigStoreCore.Interfaces;
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

        //[HttpGet(Name ="Products")]
        [HttpGet,Route("Products")]
        public async Task<List<Product>> GetProducts()
        {
            return await _layer.GetProducts();
        }

        //[HttpGet(Name = "Categories")]
        [HttpGet,Route("Categories")]
        public async Task<List<Category>> GetCategories()
        {
            return (await _layer.GetCategories());
        }
    }
}
