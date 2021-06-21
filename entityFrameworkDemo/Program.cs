using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace entityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // InsertData();
            PrintData();
        }

        private static void InsertData()
        {
            using (var context = new LibraryContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds a publisher
                var publisher = new Publisher
                {
                    Name = "Mariner Books"
                };
                context.Publisher.Add(publisher);

                // Adds an author
                var author1 = new Author
                {
                    Name = "J.R.R. Tolkien"
                };
                context.Author.Add(author1);

                var author2 = new Author
                {
                    Name = "Emma Donoghue"
                };
                context.Author.Add(author2);

                // Adds some books
                context.Book.Add(new Book
                {
                    ISBN = "978-0544003415",
                    Title = "The Lord of the Rings",
                    Author = author1,
                    Language = "English",
                    Pages = 1216,
                    IsAvailble = true,
                    Publisher = publisher
                });
                context.Book.Add(new Book
                {
                    ISBN = "978-0547247762",
                    Title = "The Sealed Letter",
                    Author = author1,
                    Language = "English",
                    Pages = 416,
                    IsAvailble = false,
                    Publisher = publisher
                });
                context.Book.Add(new Book
                {
                    ISBN = "978-0547247765",
                    Title = "The Sealed Letter",
                    Author = author2,
                    Language = "English",
                    Pages = 416,
                    IsAvailble = false,
                    Publisher = publisher
                });

                // Saves changes
                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            // Gets and prints all books in database
            using (var context = new LibraryContext())
            {
                var books = context.Book
                    .Include(p => p.Publisher)
                    .Include(b => b.Author);
                foreach (var book in books)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ISBN: {book.ISBN}");
                    data.AppendLine($"Title: {book.Title}");
                    data.AppendLine($"Publisher: {book.Publisher.Name}");
                    data.AppendLine($"Author: {book.Author.Name}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}
