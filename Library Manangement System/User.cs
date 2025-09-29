using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class User
    {
        public int Id { get; }
        public string Name { get; }
        private List<Book> BorrowedBooks { get; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            if (book.IsAvailable)
            {
                book.Borrow();
                BorrowedBooks.Add(book);
            }
            else
            {
                Console.WriteLine("Book not available for borrowing.");
            }
        }

        public void ReturnBook(Book book)
        {
            if (BorrowedBooks.Contains(book))
            {
                book.ReturnBook();
                BorrowedBooks.Remove(book);
            }
        }
    }
}
