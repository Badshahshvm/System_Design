using System;
using System.Collections.Generic;
using System.Linq;

// ---- Entities ----
class Book
{
    public int Id { get; }
    public string Title { get; }
    public string Author { get; }
    public bool IsAvailable { get; private set; }

    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
        IsAvailable = true;
    }

    public void MarkBorrowed() => IsAvailable = false;
    public void MarkReturned() => IsAvailable = true;
}

class User
{
    public int Id { get; }
    public string Name { get; }
    public List<Book> BorrowedBooks { get; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
        BorrowedBooks = new List<Book>();
    }
}

// ---- Interfaces ----
interface IBorrowService
{
    void BorrowBook(User user, Book book);
    void ReturnBook(User user, Book book);
}

interface ISearchService
{
    Book SearchBook(IEnumerable<Book> books, string title);
}

interface ILibraryRepository
{
    void AddBook(Book book);
    void RegisterUser(User user);
    IEnumerable<Book> GetBooks();
    IEnumerable<User> GetUsers();
}

// ---- Implementations ----
class BorrowService : IBorrowService
{
    public void BorrowBook(User user, Book book)
    {
        if (book.IsAvailable)
        {
            book.MarkBorrowed();
            user.BorrowedBooks.Add(book);
            Console.WriteLine($"{book.Title} borrowed by {user.Name}.");
        }
        else
        {
            Console.WriteLine($"{book.Title} is not available.");
        }
    }

    public void ReturnBook(User user, Book book)
    {
        if (user.BorrowedBooks.Contains(book))
        {
            book.MarkReturned();
            user.BorrowedBooks.Remove(book);
            Console.WriteLine($"{book.Title} returned by {user.Name}.");
        }
    }
}

class SearchService : ISearchService
{
    public Book SearchBook(IEnumerable<Book> books, string title)
    {
        return books.FirstOrDefault(b => 
            b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }
}

class LibraryRepository : ILibraryRepository
{
    private readonly List<Book> _books = new();
    private readonly List<User> _users = new();

    public void AddBook(Book book) => _books.Add(book);
    public void RegisterUser(User user) => _users.Add(user);
    public IEnumerable<Book> GetBooks() => _books;
    public IEnumerable<User> GetUsers() => _users;
}

// ---- Main Program ----
class Program
{
    static void Main()
    {
        ILibraryRepository library = new LibraryRepository();
        IBorrowService borrowService = new BorrowService();
        ISearchService searchService = new SearchService();

        // Add books
        Book book1 = new Book(1, "C# Basics", "Anders Hejlsberg");
        Book book2 = new Book(2, "Clean Code", "Robert Martin");
        library.AddBook(book1);
        library.AddBook(book2);

        // Register user
        User user1 = new User(101, "Shivam");
        library.RegisterUser(user1);

        // Search & Borrow
        Book foundBook = searchService.SearchBook(library.GetBooks(), "C# Basics");
        if (foundBook != null)
        {
            borrowService.BorrowBook(user1, foundBook);
        }

        // Return
        borrowService.ReturnBook(user1, foundBook);
    }
}
