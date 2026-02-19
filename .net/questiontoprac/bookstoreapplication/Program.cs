
using System.Net;

public class InvalidBookInputException : Exception
{
    public InvalidBookInputException(string message) : base(message)
    {
        
    }
}
public class Book
{
    public string Id{get; set;}
    public string Title{get; set;}

    public string Author{get; set;}

    private int price ;

    public int Price
    {
        get
        {
            return price;
        }
        set
        {
            if (value < 0)
            {
                throw new InvalidBookInputException("Price cannot be negative");
            }
            price=value;
        }
    }

    private int stock;
    public int Stock
    {
        get
        {
            return stock;
        }
        set
        {
            if (value < 0)
            {
                throw new InvalidBookInputException("Stock cannot be negative");
            }
            stock=value;
        }
    }
}
public class BookUtility
{
    private Book book;
    public BookUtility(Book book)
    {
        this.book=book;
    }
    public void GetBookDetails()
    {
        Console.WriteLine($"<bookid>: {book.Id} <Title>{book.Title} <Price>{book.Price} <stock>{book.Stock}");
    }

    public void UpdateBookPrice(int newPrice)
    {
        book.Price=newPrice;
    }
    public void UpdateBookstock(int newStock)
    {
        book.Stock=newStock;
    }
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the inputs:{id} {Title} {Author} {price} {stock} : ");
        string input = Console.ReadLine();
        string []inarr=input.Split(' ');

        Book book = new Book()
        {
            Id = inarr[0],
            Title=inarr[1],
            Author=String.Empty,
            Price=int.Parse(inarr[2]),
            Stock=int.Parse(inarr[3])
        };
        BookUtility utility = new BookUtility(book);
        string choice;
        bool running = true;
        while (running)
        {
            choice=Console.ReadLine();
            switch (choice)
            {
                case "1":
                    utility.GetBookDetails();
                    break;
                case "2":
                    int newPrice = int.Parse(Console.ReadLine());
                    utility.UpdateBookPrice(newPrice);
                    break;
                case "3":
                    int newStock = int.Parse(Console.ReadLine());
                    utility.UpdateBookstock(newStock);
                    break;
                case "4":
                    running=false;
                    Console.WriteLine("thanks for using the app");
                    break;
                default:
                    Console.WriteLine("Enter right Choice");
                    break;
            }
        }
    }
}