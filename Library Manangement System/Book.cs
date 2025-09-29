using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Book
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

        public void Borrow()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine($"{Title} borrowed.");
            }
            else
            {
                Console.WriteLine($"{Title} is not available.");
            }
        }

        public void ReturnBook()
        {
            IsAvailable = true;
            Console.WriteLine($"{Title} returned.");
        }
    }
}
