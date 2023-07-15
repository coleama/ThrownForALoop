﻿List<Product> products = new List<Product>()
{
  new Product()
    { 
        Name = "Football", 
        Price = 15.00M, 
        Sold = false,
        StockDate = new Date(2022, 10, 20),
        ManufactureYear = 2010,
        Condition = 4.2
    },
    new Product() 
    { 
        Name = "Hockey Stick", 
        Price = 12.99M, 
        Sold = false,
        StockDate = new Date(2022, 10, 20),
        ManufactureYear = 2011,
        Condition = 4.5
    },
    new Product()
    {
      Name = "Soccer ball",
      Price = 15.99M,
      Sold = false,
      StockDate = new Date(2022, 10, 20),
      ManufactureYear = 2010,
      Condition = 4.6
    }
};
string greeting = @"Welcome to Thrown For a Loop
Your one-stop shop for used sporting equipment";



Console.WriteLine(greeting);
string choice = null!;
while (choice != "0") {
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Latest Products");
    choice = Console.ReadLine()!;
    if (choice == "0") {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1") {
        ListProducts();
    }
    else if (choice == "2") {
        ViewProductDetails();
    }
    else if (choice == "3") {
        ViewLatestProducts();
    }
}




void ViewProductDetails()
{
    ListProducts();
    Product chosenProduct = null!;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine()!.Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Come on man!");
        }
    }

    DateTime now = DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;
    Console.WriteLine(@$"You chose: 
    {chosenProduct.Name}, which costs ${chosenProduct.Price}.
    It is {now.Year - chosenProduct.ManufactureYear} years old. 
    It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}
    Condition: {chosenProduct.Condition}");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts() {
    List<Product> latestProducts = new();

    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);

    foreach (Product product in products){

      if(product.StockDate > threeMonthsAgo && !product.Sold) {
        latestProducts.Add(product);
      }  
    }

    for (int i = 0; i < latestProducts.Count; i++) {
        Console.WriteLine($"{1+i}. {latestProducts[i].Name}");
    }
}