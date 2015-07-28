using Movies.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Repository
{
    public interface IMovie
    {
        ICollection<Movie> GetAllMovies();
        Movie GetMovie(int movieId);
        bool AddMovie(Movie movie);
        bool UpdateMovie(int movieId, Movie movie);
        bool DeleteMovie(int movieId);
    }
}
