using Microsoft.EntityFrameworkCore;
using CinemaFanShop.Infrastructure.Data;
using CinemaFanShop.Infrastructure.Data.Entities;
using CinemaFanShop.Core.Contracts;

namespace CinemaFanShop.Core.Services
{
    public class FavoritesService : IFavorites
    {
        private readonly ApplicationDbContext _context;
        public FavoritesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool RemoveFromFavorites(string userId, int productId)
        {
            var favorite = _context.Favorites.FirstOrDefault(fv => fv.UserId == userId && fv.ProductId == productId);

            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
            }
            return _context.SaveChanges() != 0;
        }

        public bool AddToFavorites(string userId, int productId)
        {
            var userProduct = new Favorites
            {
                UserId = userId,
                ProductId = productId
            };
            _context.Favorites.Add(userProduct);
            return _context.SaveChanges() != 0;
        }

        public bool IsProductFavorites(string userId, int productId)
        {
            return  _context.Favorites
                .Any(fv => fv.UserId == userId && fv.ProductId == productId);
        }
        public IEnumerable<Product> GetUserFavorites(string userId)
        {
            return _context.Favorites
                .Where(fv => fv.UserId == userId)
                .Select(fv => fv.Product).ToList();
        }
    }
}
