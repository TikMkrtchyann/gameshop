namespace Gameshop2.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
