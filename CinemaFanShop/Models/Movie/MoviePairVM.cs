using System.ComponentModel.DataAnnotations;

namespace CinemaFanShop.Models.Movie
{
    public class MoviePairVM
    {
        public int Id { get; set; }

        [Display(Name = "Movie")]
        public string Name { get; set; } = null!;
    }

}
