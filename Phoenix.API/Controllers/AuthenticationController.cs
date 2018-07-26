using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Phoenix.Models;

namespace Phoenix.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly PhoenixDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;

        public AuthenticationController(PhoenixDbContext context, SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager, IConfiguration config)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        /// <summary>
        /// User windows authentication
        /// </summary>
        /// <returns></returns>
        [HttpGet("windows")]
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

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]Login login)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = login.UserName };
                var result = await _signInManager.UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest(ModelState);
        }

        private JwtSecurityToken BuildToken(AppUser appuser)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, appuser.NormalizedUserName),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issurer"],
                _config["Jwt:Issurer"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            return token;
        }
    }
}