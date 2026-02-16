using CinemaFanShop.Infrastructure.Data.Entities;
using CinemaFanShop.Models.Client;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaFanShop.Controllers
{
    public class ClientController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ClientController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        // GET: ClientController
        public async Task<IActionResult> Index()
        {
            var allUsers = this._userManager.Users
                .Select(u => new ClientIndexVM
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Address = u.Address,
                    Email = u.Email,
                })
                .ToList();

            // Id на всички администратори
            var adminIds = (await _userManager.GetUsersInRoleAsync("Administrator"))
                .Select(a => a.Id).ToList();

            //Ако потребителят е в списъка, то IsAdmin става true
            foreach (var user in allUsers)
            {
                user.IsAdmin = adminIds.Contains(user.Id);
            }

            //Вадим само клиентите без администратора и ги сортираме по username
            var users = allUsers.Where(x => x.IsAdmin == false)
                .OrderBy(x => x.UserName).ToList();

            //връщаме списъка
            return this.View(users);
        }
    }
}
