using CinemaFanShop.Infrastructure.Data;
using CinemaFanShop.Infrastructure.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebShopApp.Core.Contracts;

namespace WebShopApp.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Movie GetMovieById(int movieId)
        {
            return _context.Movies.Find(movieId);
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = _context.Movies.ToList();
            return movies;
        }

        public List<Product> GetProductsByMovie(int movieId)
        {
            return _context.Products
                .Where(x => x.MovieId == movieId)
                .ToList();
        }
    }
}
