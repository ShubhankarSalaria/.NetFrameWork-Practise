namespace MovieLibraryApp.Models.Interfaces
{
    public interface IFilm
    {
        string Title { get; set; }
        string Director { get; set; }
        int Year { get; set; }
    }
}