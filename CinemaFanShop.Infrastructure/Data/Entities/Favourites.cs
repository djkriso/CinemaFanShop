using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaFanShop.Infrastructure.Data.Entities
{
    public class Favourites
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;
            
        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}