using System.Collections.Generic;

namespace entityFrameworkDemo
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        // public string Author { get; set; }
        public virtual Author Author { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public bool IsAvailble { get; set; }
        public virtual Publisher Publisher { get; set; }
    }

    public class Publisher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }

    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}