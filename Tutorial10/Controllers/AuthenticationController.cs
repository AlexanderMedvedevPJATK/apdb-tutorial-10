using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial10.Context;
using Tutorial10.DTOs.Authentication;
using Tutorial10.Helpers;
using Tutorial10.Models;

namespace Tutorial10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        
        private readonly Apbd10Context _context;
        
        public AuthenticationController(Apbd10Context context)
        {
            _context = context;
        }
        
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult RegisterStudent(RegisterRequest request)
        {
            var hashedPasswordAndSalt = SecurityHelpers.GetHashedPasswordAndSalt(request.Password);
            var user = new AppUser()
            {
                Username = request.Username,
                Password = hashedPasswordAndSalt.Item1,
                Salt = hashedPasswordAndSalt.Item2,
                RefreshToken = SecurityHelpers.GenerateRefreshToken(),
                RefreshTokenExp = DateTime.Now.AddDays(1)
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        
            return Ok();
        }
    }
}
