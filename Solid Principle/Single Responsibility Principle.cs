using System;
using System.Collections.Generic;

// ✅ Product class - Responsible only for product details
public class Product
{
    public string Name { get; }
    public decimal Price { get; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

// ✅ Cart class - Responsible only for managing products in cart
public class Cart
{
    private readonly List<Product> _products = new List<Product>();

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public List<Product> GetProducts()
    {
        return _products;
    }
}

// ✅ PriceCalculator class - Responsible only for calculating total price
public class PriceCalculator
{
    public decimal CalculateTotal(List<Product> products)
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.Price;
        }
        return total;
    }
}

// ✅ InvoicePrinter class - Responsible only for printing invoice
public class InvoicePrinter
{
    public void PrintInvoice(List<Product> products, decimal total)
    {
        Console.WriteLine("===== Invoice =====");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name} - ₹{product.Price}");
        }
        Console.WriteLine("-------------------");
        Console.WriteLine($"Total: ₹{total}");
        Console.WriteLine("===================");
    }
}

// ✅ Main Program
class Program
{
    static void Main()
    {
        // Create products
        Product p1 = new Product("Pen", 10);
        Product p2 = new Product("Notebook", 50);
        Product p3 = new Product("Bag", 500);

        // Add products to cart
        Cart cart = new Cart();
        cart.AddProduct(p1);
        cart.AddProduct(p2);
        cart.AddProduct(p3);

        // Calculate total price
        PriceCalculator calculator = new PriceCalculator();
        decimal total = calculator.CalculateTotal(cart.GetProducts());

        // Print invoice
        InvoicePrinter printer = new InvoicePrinter();
        printer.PrintInvoice(cart.GetProducts(), total);
    }
}
