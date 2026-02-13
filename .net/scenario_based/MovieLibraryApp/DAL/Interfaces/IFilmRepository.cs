using MovieLibraryApp.Models.Interfaces;

namespace MovieLibraryApp.DAL.Interfaces
{
    public interface IFilmRepository
    {
        void AddFilm(IFilm film);
        void RemoveFilm(string title);
        List<IFilm> GetFilms();
    }
}
