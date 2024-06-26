using System.ComponentModel.DataAnnotations;

namespace Tutorial10.Models
{
    public class AppUser
    {
        [Key]
        public int IdUser { get; set; }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public DateTime? RefreshTokenExp { get; set; }
    }
}