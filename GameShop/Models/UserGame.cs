using System.ComponentModel.DataAnnotations;

namespace GameShop.Models
{
    public class UserGame
    {
        [Key]
        public int Id { get; set; }
        
        // Foreign keys
        public string UserId { get; set; }
        public int GameId { get; set; }

        public User User { get; set; }
        public Game? Game { get; set; }

    }
}
