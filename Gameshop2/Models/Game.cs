using System.ComponentModel.DataAnnotations;

namespace Gameshop2.Models
{
    public class Game
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Developer { get; set; }
        public decimal Price { get; set; }
        public string? Genre { get; set; }
        public DateTime RealeseDate { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Cart> Carts { get; set;}
    }
}
