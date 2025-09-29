using ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Library library = new Library();

        // Add books
        Book book1 = new Book(1, "C# Basics", "Anders Hejlsberg");
        Book book2 = new Book(2, "Clean Code", "Robert Martin");
        library.AddBook(book1);
        library.AddBook(book2);

        // Register user
        User user1 = new User(101, "Shivam");
        library.RegisterUser(user1);

        // Borrow book
        Book foundBook = library.SearchBook("C# Basics");
        if (foundBook != null)
        {
            user1.BorrowBook(foundBook);
        }

        // Return book
        user1.ReturnBook(foundBook);
    }
}