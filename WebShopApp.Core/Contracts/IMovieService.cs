using CinemaFanShop.Infrastructure.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopApp.Core.Contracts
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
        Movie GetMovieById(int movieId);
        List<Product> GetProductsByMovie(int movieId);
    }
}
