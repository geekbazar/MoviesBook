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
        private readonly IMovie _movie;

        public MoviesController(IMovie movie)
        {
            this._movie = movie;
        }

        [HttpGet]
        [Route("api/movies")]
        public ICollection<Movie> GetAllMovies()
        {
            return this._movie.GetAllMovies();
        }

        [HttpGet]
        [Route("api/movies/{movieId}")]
        public Movie GetMovie(int movieId)
        {
            return this._movie.GetMovie(movieId);
        }

        [HttpPost]
        [Route("api/movies")]
        public HttpResponseMessage AddMovie([FromBody]Movie movie)
        {
            var isMovieAdded = this._movie.AddMovie(movie);

            if (isMovieAdded)
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
            }
            else
                return new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound };
        }

        [HttpPut]
        [Route("api/movies/{movieId}")]
        public HttpResponseMessage UpdateMovie(int movieId, [FromBody]Movie movie)
        {
            var isMovieUpdated = this._movie.UpdateMovie(movieId, movie);
            if (isMovieUpdated)
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
            }
            else
                return new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound };
        }


        [HttpDelete]
        [Route("api/movies/{movieId}")]
        public HttpResponseMessage DeleteMovie(int movieId)
        {
            var isMovieDeleted = this._movie.DeleteMovie(movieId);
            if (isMovieDeleted)
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
            }
            else
                return new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound };
        }
    }
}
