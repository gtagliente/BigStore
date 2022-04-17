// See https://aka.ms/new-console-template for more information
using BigStoreProxy;
Console.WriteLine("Hello, World!");
try {
    //BigStoreContext ct = new BigStoreContext();

    //var lst = ct.Products;
    ////foreach (var product in lst)
    //    Console.WriteLine(product.Name);

    var client = new BigStoreProxy.Client("https://localhost:7008/", new HttpClient());
    List<Product> products = client.ProductsAsync().Result.ToList() ;
    List<Category> categories = client.CategoriesAsync().Result.ToList() ;
}
catch(Exception e)
{

}

