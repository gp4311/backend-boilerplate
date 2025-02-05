using Boilerplate.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Boilerplate.Api.DTOs;
using System.Security.Claims;

namespace Boilerplate.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized("User not found in claims.");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound("User not found.");

            var profile = new UserProfile
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return Ok(profile);
        }

        [HttpGet("debug-auth")]
        public IActionResult DebugAuth()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized("User is not authenticated");

            return Ok(new { Message = "User is authenticated", UserClaims = User.Claims.Select(c => new { c.Type, c.Value }) });
        }
    }
}