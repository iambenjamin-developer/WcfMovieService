using System.Collections.Generic;
using System.Linq;

namespace WcfMovieService
{
    public class MovieService : IMovieService
    {
        private static List<Movie> _movies = new List<Movie>();
        private static int _nextId = 1;

        public bool AddMovie(Movie movie)
        {
            movie.Id = _nextId++;
            _movies.Add(movie);
            return true;
        }

        public List<Movie> GetAllMovies() => _movies;

        public Movie GetMovieById(int id) => _movies.FirstOrDefault(m => m.Id == id);

        public Movie GetMovieByCode(string code) => _movies.FirstOrDefault(m => m.Code == code);

        public bool UpdateMovie(Movie updatedMovie)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == updatedMovie.Id);
            if (movie == null) return false;

            movie.Title = updatedMovie.Title;
            movie.Director = updatedMovie.Director;
            movie.Year = updatedMovie.Year;
            movie.Code = updatedMovie.Code;
            return true;
        }

        public bool DeleteMovie(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return false;

            _movies.Remove(movie);
            return true;
        }

        public bool UpsertMovie(Movie upsertMovie)
        {
            var movie = _movies.FirstOrDefault(m => m.Code == upsertMovie.Code);
            //Actualiza el existente, sino crea uno nuevo
            if (movie != null)
            {
                movie.Title = upsertMovie.Title;
                movie.Director = upsertMovie.Director;
                movie.Year = upsertMovie.Year;
                return true;
            }
            else
            {
                //Crear una nueva pelicula 
                upsertMovie.Id = _nextId++;
                _movies.Add(upsertMovie);
                return true;
            }
        }
    }
}
