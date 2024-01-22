using System.ComponentModel.DataAnnotations.Schema;

namespace Gameshop2.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Count { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [ForeignKey("GameId")]
        public int GameId { get; set; }

        public User User { get; set; }
        public Game Game { get; set; }
    }
}
