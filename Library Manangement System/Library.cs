using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Library
    {

        private List<Book> Books { get; }
        private List<User> Users { get; }

        public Library()
        {
            Books = new List<Book>();
            Users = new List<User>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RegisterUser(User user)
        {
            Users.Add(user);
        }

        public Book SearchBook(string title)
        {
            foreach (var book in Books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return null;
        }
    }
}
