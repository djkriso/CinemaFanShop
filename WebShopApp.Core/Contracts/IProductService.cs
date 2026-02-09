using CinemaFanShop.Infrastructure.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopApp.Core.Contracts
{
    public interface IProductService
    {
        bool Create(string name, int brandId, int categoryId, int movieId, string picture, string description, int quantity, decimal price, decimal discount);


        List<Product> GetProducts();

        Product GetProductById(int productId);

        bool RemoveById(int dogproductId);

        List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName);
        bool Update(int id, string productName, int brandId, int categoryId, int categoryId1, string picture, int quantity, decimal price, decimal discount);
    }

}
