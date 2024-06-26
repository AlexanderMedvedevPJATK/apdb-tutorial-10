using Microsoft.Build.Framework;

namespace Tutorial10.DTOs.Authentication;
public class AuthenticationRequest
{
    [Required]
    public string Username { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}
