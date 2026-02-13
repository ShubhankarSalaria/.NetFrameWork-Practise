using MovieLibraryApp.Business.Interfaces;
using MovieLibraryApp.Business.Services;
using MovieLibraryApp.DAL.Interfaces;
using MovieLibraryApp.DAL.Repositories;
using MovieLibraryApp.Models;

namespace MovieLibraryApp.UI
{
    class Program
    {
        static void Main()
        {
            IFilmRepository repository = new FilmRepository();
            IFilmService service = new FilmService(repository);

            Console.WriteLine("TEST CASE 1: Adding films");

            service.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
            service.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));
            service.AddFilm(new Film("Titanic", "James Cameron", 1997));

            Console.WriteLine("Films added successfully\n");

            Console.WriteLine("TEST CASE 2: Displaying all films");

            foreach (Film film in service.GetFilms())
            {
                Console.WriteLine($"{film.Title} | {film.Director} | {film.Year}");
            }

            Console.WriteLine("\nTEST CASE 3: Search by 'Nolan'");

            foreach (Film film in service.SearchFilms("Nolan"))
            {
                Console.WriteLine($"{film.Title} | {film.Director}");
            }

            Console.WriteLine("\nTEST CASE 4: Removing Titanic");
            service.RemoveFilm("Titanic");

            foreach (Film film in service.GetFilms())
            {
                Console.WriteLine(film.Title);
            }

            Console.WriteLine("\nTEST CASE 5: Total film count");
            Console.WriteLine(service.GetTotalFilmCount());
        }
    }
}
