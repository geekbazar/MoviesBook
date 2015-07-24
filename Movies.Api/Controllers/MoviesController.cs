using Movies.Domain.Model;
using Movies.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Movies.Api.Controllers
{
    public class MoviesController : ApiController
    {
        [HttpGet]
        [Route("api/movies")]
        public ICollection<Movie> GetAllMovies()
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

        [HttpGet]
        [Route("api/movies/{movieId}")]
        public Movie GetMovie(int movieId)
        {
            if (movieId != null)
            {
                using (var db = new MoviesContext())
                {
                    return db.Movies.Where(x => x.MovieId == movieId).FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/movies")]
        public HttpResponseMessage AddMovie([FromBody]Movie movie)
        {
            if (movie != null)
            {
                using (var db = new MoviesContext())
                {
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
                }
            }
            else
                return new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound };
        }

        [HttpPut]
        [Route("api/movies/{movieId}")]
        public HttpResponseMessage UpdateMovie(int movieId, [FromBody]Movie movie)
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
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
                }
                else
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound };
            }
        }

        [HttpDelete]
        [Route("api/movies/{movieId}")]
        public HttpResponseMessage DeleteMovie(int movieId)
        {
            using (var db = new MoviesContext())
            {
                var movie = db.Movies.Where(x => x.MovieId == movieId).FirstOrDefault();
                if (movie != null)
                {
                    db.Movies.Remove(movie);
                    db.SaveChanges();
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
                }
                else
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound };
            }

        }
    }
}
