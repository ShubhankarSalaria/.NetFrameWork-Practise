public class Author
{
    public string AuthorName {get; set;}
    public string Country {get; set;}

    public Author(string name, string country)
    {
        AuthorName=name;
        Country=country;
    }
}
public class Book
{
    public string Title {get; set;}
    public int Price {get; set;}
    public Author Authobj{get; set;}

    public Book (string title , int price , Author obj)
    {
        Title=title;
        Price = price;
        Authobj = obj;
    }
}

public class Library
{
    List<Book>bookslist = new List<Book>();
    public void AddBook(Book book)
    {
        bookslist.Add(book);
    }
    public void DisplayBooks()
    {
        foreach( var books in bookslist)
        {
            Console.WriteLine(books.Title);
        }
    }
}
public class Program
{
    public static void Main()
    {
        Library lib = new Library();
        lib.AddBook(new Book("1984", 499, new Author("George Orwell", "U.K")));
        lib.AddBook(new Book("Stranger", 299, new Author("Albert Camus", "France")));
        lib.DisplayBooks();
    }
}