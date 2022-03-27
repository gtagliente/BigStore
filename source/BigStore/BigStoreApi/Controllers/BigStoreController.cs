using Microsoft.AspNetCore.Mvc;
using BigStoreCore.Interfaces;

namespace BigStoreApi.Controllers
{
    public class BigStoreController : Controller
    {
        private readonly IMainBusinessLayer _layer;

        public BigStoreController(IMainBusinessLayer layer)
        {
            _layer = layer;
        }

        //[HttpGet(Name ="Products")]
        [Route("Products")]
        public async Task<IActionResult> GetProducts()
        {
            return Json(await _layer.GetProducts());
        }

        //[HttpGet(Name = "Categories")]
        [Route("Categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Json(await _layer.GetCategories());
        }
    }
}
