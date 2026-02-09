using CinemaFanShop.Models.Brand;
using CinemaFanShop.Models.Category;
using CinemaFanShop.Models.Movie;

using System.ComponentModel.DataAnnotations;

namespace CinemaFanShop.Models.Product
    


{
    public class ProductIndexVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public int BrandId { get; set; }

        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        [Display(Name = "Movie")]
        public string MovieName { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
    }

}
