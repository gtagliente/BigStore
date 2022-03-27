// See https://aka.ms/new-console-template for more information
using BigStoreCore.Models;
Console.WriteLine("Hello, World!");
try { 
BigStoreContext ct = new BigStoreContext();

var lst = ct.Products;
//foreach (var product in lst)
//    Console.WriteLine(product.Name);
}
catch(Exception e)
{

}

