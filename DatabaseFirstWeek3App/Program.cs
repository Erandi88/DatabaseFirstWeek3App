using DatabaseFirstWeek3App.Models;
using System.Collections.Generic;
using System.Net;

/* Create Data */
var dbContext = new StoreDbContext();

var productId = dbContext.Products.Max(e => e.Id)+1;

Console.WriteLine("***** New Product *****");

Console.Write("\nEnter Product Name : ");
var name = Console.ReadLine();

Console.Write("Enter Product Price : ");
var price = Console.ReadLine();

var product = new Product
{
    Id = productId,
    Name = name,
    Price = decimal.Parse(price)
};
dbContext.Products.Add(product);
dbContext.SaveChanges();
Console.WriteLine("\nProduct Data Saved Sucessfully.");

/* Retrive, Update & Delete */

Console.Write("\nEnter Product Name : ");
var productName = Console.ReadLine();
var retrievedProduct = dbContext.Products.FirstOrDefault(p => p.Name == productName);

Boolean b = true;
while (b){
     Console.WriteLine("\nA. Show Product Details");
     Console.WriteLine("B. Update Product Price");
     Console.WriteLine("C. Delete the product ");

     Console.Write("\nPlease Select a Option : ");
     var option = Console.ReadLine();

        if (retrievedProduct != null)
        {
            switch (option)
            {
                case "A":
                    Console.WriteLine("\n***** Product Details *****");

                    Console.WriteLine($"\nProduct Name : {retrievedProduct.Name.Trim()}, Price : {retrievedProduct.Price}");
                    break;

                case "B":
                    Console.WriteLine("\n***** Update Product Details *****");
                    Console.Write("\nUpdate Product Price : ");

                    var updateProductPrice = Console.ReadLine();
                    retrievedProduct.Price = decimal.Parse(updateProductPrice);
                    dbContext.SaveChanges();

                    Console.WriteLine("\nPrice Updated Sucessfully.");
                    break;

                case "C":

                    Console.Write("\nDo you want to delete this Product (Y/N) : ");
                    var response = Console.ReadLine();
                    if (response.Equals("Y"))
                    {
                        dbContext.Products.Remove(retrievedProduct);
                        dbContext.SaveChanges();
                        Console.WriteLine("\nProduct Deleted Successfully.");
                        b = false;
                     
                    }else
                    {
                        Console.WriteLine($"\nProduct Name : {retrievedProduct.Name.Trim()}, Price : {retrievedProduct.Price}");

                    }
                    break;

                default: Console.WriteLine("\nInvalid Entry.");
                    break;
        
            }
        
        }else
        {
            Console.WriteLine("Product not found.");
        }


    }


