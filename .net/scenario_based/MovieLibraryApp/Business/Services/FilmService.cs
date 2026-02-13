using MovieLibraryApp.Models.Interfaces;
using MovieLibraryApp.Business.Interfaces;
using MovieLibraryApp.Models;
using MovieLibraryApp.DAL.Interfaces;

namespace MovieLibraryApp.Business.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _repository;

        public FilmService(IFilmRepository repository)
        {
            _repository = repository;
        }

        public void AddFilm(IFilm film)
        {
            _repository.AddFilm(film);
        }

        public void RemoveFilm(string title)
        {
            _repository.RemoveFilm(title);
        }

        public List<IFilm> GetFilms()
        {
            return _repository.GetFilms();
        }

        public List<IFilm> SearchFilms(string query)
        {
            List<IFilm> result = new List<IFilm>();
        
            foreach (IFilm f in _repository.GetFilms())
            {
                Film filmObj = f as Film;
        
                if (f.Title.ToLower().Contains(query.ToLower()) ||
                    (filmObj != null && filmObj.Director.ToLower().Contains(query.ToLower())))
                {
                    result.Add(f);
                }
            }
        
            return result;
        }

        public int GetTotalFilmCount()
        {
            return _repository.GetFilms().Count;
        }
    }
}