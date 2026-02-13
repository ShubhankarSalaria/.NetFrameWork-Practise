using MovieLibraryApp.Models.Interfaces;

namespace MovieLibraryApp.Business.Interfaces
{
    public interface IFilmService
    {
        void AddFilm(IFilm film);
        void RemoveFilm(string title);
        List<IFilm> GetFilms();
        List<IFilm> SearchFilms(string query);
        int GetTotalFilmCount();
    }
}