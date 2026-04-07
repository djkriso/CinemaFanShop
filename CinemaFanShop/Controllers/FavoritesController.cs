using CinemaFanShop.Models.Product;

using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

using WebShopApp.Core.Contracts;

namespace CinemaFanShop.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavorites favouritesService;

        public FavoritesController(IFavorites FavoritesService)
        {
            this.favouritesService = FavoritesService;
        }
        [HttpGet]

        public IActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            List<ProductIndexVM> products = favouritesService.GetUserFavorites(userId)
            .Select(product => new ProductIndexVM
            {
                Id = product.Id,
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                BrandName = product.Brand.BrandName,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                Picture = product.Picture,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount
            }).ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Add(int productId)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }


            bool isInFavorites = FavoritesService.IsProductFavorites(userId, productId);

            if (!isInFavorites)
            {
                FavoritesService.AddToFavorites(userId, productId);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Remove(int productId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);



            bool isInFavorites = FavoritesService.IsProductFavorites(userId, productId);
            if (isInFavorites)
            {
                FavoritesService.RemoveFromFavorites(userId, productId);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
    

