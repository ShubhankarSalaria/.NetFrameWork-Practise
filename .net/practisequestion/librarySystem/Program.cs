using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Book
{
    public int Id {get; set;}
    public string Title {get; set;}
    public string Author {get; set;}
    public string Genre {get; set;}
    public int PublicationYear {get; set;}
}

public class LibraryUtility
{
    private SortedDictionary<int , Book>books = new SortedDictionary<int, Book>();
    private int bookId = 1;
    public void AddBook(string title , string author , string genre , int year)
    {
        Book book = new Book()
        {
           Id =bookId,
          Title =title,
          Author=author,
          Genre=genre,
          PublicationYear=year
        };
        books.Add(bookId,book);
        bookId++;
    }

    public SortedDictionary<string , List<Book>> GroupBooksByGenre()
    {
        SortedDictionary<string,List<Book>> result = new SortedDictionary<string, List<Book>>();
        foreach(var val in books.Values)
        {
            if (!result.ContainsKey(val.Genre))
            {
                result[val.Genre]= new List<Book>();

            }
            result[val.Genre].Add(val);
        }
        return result;
    }

    public List<Book> GetBooksByAuthor(string author)
    {
        List<Book>AuthBook = new List<Book>();
        foreach( var book in books.Values)
        {
            if (book.Author.ToLower() == author)
            {
                AuthBook.Add(book);
            }
        }
        return AuthBook;
    }

    public int GetTotalBooksCount()
    {
        return books.Count;
    }
}
    public class Program
    {
        public static void Main()
        {
        LibraryUtility library = new LibraryUtility();

        // Sample Use Case 1 → Add Books
        library.AddBook("The Hobbit", "J.R.R. Tolkien", "Fiction", 1937);
        library.AddBook("Sherlock Holmes", "Arthur Conan Doyle", "Mystery", 1892);
        library.AddBook("Atomic Habits", "James Clear", "Non-Fiction", 2018);
        library.AddBook("LOTR", "J.R.R. Tolkien", "Fiction", 1954);

        // Sample Use Case 2 → Display Books Grouped By Genre
        Console.WriteLine("Books Grouped By Genre:");
        var grouped = library.GroupBooksByGenre();

        foreach (var genre in grouped)
        {
            Console.WriteLine($"\nGenre: {genre.Key}");

            foreach (var book in genre.Value)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Year: {book.PublicationYear}");
            }
        }

        // Sample Use Case 3 → Search Books By Author
        Console.WriteLine("\nBooks By Author (J.R.R. Tolkien):");
        var authorBooks = library.GetBooksByAuthor("J.R.R. Tolkien");

        foreach (var book in authorBooks)
        {
            Console.WriteLine($"{book.Title} ({book.PublicationYear})");
        }

        // Sample Use Case 4 → Statistics
        Console.WriteLine($"\nTotal Books: {library.GetTotalBooksCount()}");
      }
    }
