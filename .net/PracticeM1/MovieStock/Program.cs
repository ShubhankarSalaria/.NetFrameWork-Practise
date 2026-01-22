public class Movie
{
    public string Title {get; set;}
    public string Artist {get; set;}
    public string Genre {get; set;}
    public int Ratings {get; set;}
}

public class Program
{
    public static List<Movie> MovieList=new List<Movie>();
    public void AddMovie(string MovieDetails)
    {
        string []detail = MovieDetails.Split(',');
        Movie nMovie = new Movie
        {
            Title=detail[0],
            Artist=detail[1],
            Genre=detail[2],
            Ratings=int.Parse(detail[3])
        };
        MovieList.Add(nMovie);
    }
    public List<Movie> ViewMoviesByGenre(string genre)
    {
        List<Movie>ans=new List<Movie>();
        foreach(var move in MovieList)
        {
            if (move.Genre == genre)
            {
                ans.Add(move);
            }
        }
        return ans;
    }
    public List<Movie>ViewMovieRating()
    {
        var ans = MovieList.OrderBy(x=>x.Ratings);
        return ans.ToList();
    }
    public static void Main(string []args)
    {
        Program pr = new Program();
        pr.AddMovie("Inception,Christopher Nolan,Sci-Fi,9");
        pr.AddMovie("Interstellar,Christopher Nolan,Sci-Fi,8");
        pr.AddMovie("Titanic,James Cameron,Romance,7");
        pr.AddMovie("Avengers,Russo Brothers,Action,8");

        // Example: View Sci-Fi movies
        var sciFiMovies = pr.ViewMoviesByGenre("Sci-Fi");

        Console.WriteLine("--------Movies as per Genre!---------");
        foreach (var movie in sciFiMovies)
        {
            Console.WriteLine($"{movie.Title} - {movie.Ratings}");
        }

        Console.WriteLine("-------Movies as per Rating!---------");
        var  RattingSort = pr.ViewMovieRating();
        foreach (var movie in RattingSort)
        {
             Console.WriteLine($"{movie.Title} - {movie.Ratings}");
        }
    }
}