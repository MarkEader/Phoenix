using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Models;

namespace Phoenix.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly PhoenixDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationController(PhoenixDbContext context, SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("windowsAuth")]
        public async Task<IActionResult> WindowsAuthentication()
        {
            var response = Unauthorized();
            var windowsIndentity = WindowsIdentity.GetCurrent();

            //if (windowsIndentity == null) return response;

            if (windowsIndentity.IsAuthenticated && !string.IsNullOrEmpty(windowsIndentity.Name))
            {
                var domainAndUserNameArray = windowsIndentity.Name.Split('\\');
                var userName = string.Empty;
                var domain = string.Empty;
                if (domainAndUserNameArray.Length == 2)
                {
                    userName = domainAndUserNameArray[1];
                    domain = domainAndUserNameArray[0];
                }
                var appuser = await _signInManager.UserManager.FindByNameAsync(userName.ToLower());
                if (appuser != null)
                {
                    var token = BuildToken(appuser);
                    return Ok(new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo
                    });
                }
            }

            return response;
        }

        private JwtSecurityToken BuildToken(AppUser appuser)
        {
            
        }
    }
}