using CinemaFanShop.Models.Product;

using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

using WebShopApp.Core.Contracts;

namespace CinemaFanShop.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavorites _favoritesService;

        public FavoritesController(IFavorites favoritesService)
        {
            this._favoritesService = favoritesService;
        }
        [HttpGet]

        public IActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            List<ProductIndexVM> products = _favoritesService.GetUserFavorites(userId)
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


            bool isInFavorites = _favoritesService.IsProductFavorites(userId, productId);

            if (!isInFavorites)
            {
                _favoritesService.AddToFavorites(userId, productId);
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



            bool isInFavorites = _favoritesService.IsProductFavorites(userId, productId);
            if (isInFavorites)
            {
                _favoritesService.RemoveFromFavorites(userId, productId);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
    

