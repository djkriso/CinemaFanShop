using CinemaFanShop.Infrastructure.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopApp.Core.Contracts
{
    public interface IFavorites
    {
        IEnumerable<Product> GetUserFavorites(string userId);
        bool IsProductFavorites(string userId, int productId);
        bool AddToFavorites(string userId, int productId);
        bool RemoveFromFavorites(string userId, int productId);

    }
}
