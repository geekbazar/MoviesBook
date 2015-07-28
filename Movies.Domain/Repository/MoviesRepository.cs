using Movies.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Repository
{
   public class MoviesRepository: IMovie
    {
        public ICollection<Model.Movie> GetAllMovies()
        {
            IQueryable<Movie> movies;
            using (var db = new MoviesContext())
            {
                movies = db.Movies;
                if (movies.Any() == false)
                {
                    return null;
                }
                else
                {
                    return movies.ToList();
                }
            }
        }

        public Model.Movie GetMovie(int movieId)
        {
            using (var db = new MoviesContext())
            {
                return db.Movies.Where(x => x.MovieId == movieId).FirstOrDefault();
            }
        }

        public bool AddMovie(Model.Movie movie)
        {
            if (movie != null)
            {
                using (var db = new MoviesContext())
                {
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    return true;
                }
            }
            else
                return false;
        }

        public bool UpdateMovie(int movieId, Model.Movie movie)
        {
             if (movie == null)
            {
                throw new ArgumentNullException("movie");
            }

             using (var db = new MoviesContext())
             {
                 var movieToUpdate = db.Movies.Where(x => x.MovieId == movie.MovieId).FirstOrDefault();
                 if (movieToUpdate != null)
                 {
                     movieToUpdate.Title = movie.Title;//perform validations.
                     movieToUpdate.Genre = movie.Genre;
                     movieToUpdate.ReleaseDate = movie.ReleaseDate;
                     movieToUpdate.Rating = movie.Rating;
                     db.Entry(movieToUpdate).State = EntityState.Modified;
                     db.SaveChanges();
                     return true;
                 }
                 else
                     return false;
             }
        }

        public bool DeleteMovie(int movieId)
        {
            using (var db = new MoviesContext())
            {
                var movie = db.Movies.Where(x => x.MovieId == movieId).FirstOrDefault();
                if (movie != null)
                {
                    db.Movies.Remove(movie);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
