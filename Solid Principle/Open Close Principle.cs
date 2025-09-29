
//////
using System;
using System.Collections.Generic;

// ✅ Product class - only product details
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

// ✅ Cart class - only manages products
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

// ✅ PriceCalculator interface (OCP extension point)
public interface IPriceCalculator
{
    decimal CalculateTotal(List<Product> products);
}

// ✅ Normal calculator (no discount, no tax)
public class RegularPriceCalculator : IPriceCalculator
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

// ✅ Discount calculator (extends without modifying Regular)
public class DiscountPriceCalculator : IPriceCalculator
{
    private readonly decimal _discountPercent;

    public DiscountPriceCalculator(decimal discountPercent)
    {
        _discountPercent = discountPercent;
    }

    public decimal CalculateTotal(List<Product> products)
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.Price;
        }
        return total - (total * _discountPercent / 100);
    }
}

// ✅ Invoice Printer interface (OCP extension point)
public interface IInvoicePrinter
{
    void PrintInvoice(List<Product> products, decimal total);
}

// ✅ Simple text invoice
public class TextInvoicePrinter : IInvoicePrinter
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

// ✅ Fancy invoice (extended without modifying old printer)
public class FancyInvoicePrinter : IInvoicePrinter
{
    public void PrintInvoice(List<Product> products, decimal total)
    {
        Console.WriteLine("********** Invoice **********");
        foreach (var product in products)
        {
            Console.WriteLine($"Item: {product.Name} | Price: ₹{product.Price}");
        }
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"TOTAL PAYABLE: ₹{total}");
        Console.WriteLine("*****************************");
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

        // Choose calculator (can swap without modifying existing code)
        IPriceCalculator calculator = new DiscountPriceCalculator(10); // 10% discount
        decimal total = calculator.CalculateTotal(cart.GetProducts());

        // Choose printer (can swap without modifying existing code)
        IInvoicePrinter printer =
