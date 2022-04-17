using BigStoreApi.Controllers;
using BigStoreCore.Interfaces;
using BigStoreCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BigStoreApi_CustomerExtended.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BigStoreCustomerExtendedController : BigStoreController
    {
        public BigStoreCustomerExtendedController(IMainBusinessLayer layer):base(layer)
        {
        }
        
        [HttpGet,Route("ProductsExt")]
        public async Task<Product> GetProductsExt()
        {
            return (await _layer.GetProducts()).FirstOrDefault();
        }
    }
}
