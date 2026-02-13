using MovieLibraryApp.Models;
using MovieLibraryApp.Models.Interfaces;
using MovieLibraryApp.DAL.Interfaces;

namespace MovieLibraryApp.DAL.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private List<IFilm> _films = new List<IFilm>();

        public void AddFilm(IFilm film)
        {
            _films.Add(film);
        }

        public void RemoveFilm(string title)
        {
            var film = _films.FirstOrDefault(f => f.Title == title);
            if (film != null)
            {
                _films.Remove(film);
            }
        }

        public List<IFilm> GetFilms()
        {
            return _films;
        }
    }
}
