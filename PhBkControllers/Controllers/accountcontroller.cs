

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PhBkViews.AspNetReg;

namespace PhBkControllers.Controllers
{
    [ApiController]
    public class accountcontroller : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public accountcontroller(
                    IHttpContextAccessor httpContextAccessor,
                    UserManager<IdentityUser> userManager,
                    RoleManager<IdentityRole> roleManager,
                    IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Login([FromBody] loginbindingmodel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token_type = "Bearer",
                    user_name = model.UserName,
                    access_token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("api/[controller]/register")]
        public async Task<IActionResult> Register([FromBody] registerbindingmodel model)
        {
            await CreateAdminAndGuest();
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new responsebindingmodel { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new responsebindingmodel { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new responsebindingmodel { Status = "Success", Message = "User created successfully!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(8),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        // POST api/Account/ChangePassword
        [HttpPost]
        [Route("api/[controller]/ChangePassword")]
        public async Task<ActionResult> ChangePassword(changepasswordbindingmodel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string? userName = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userManager.FindByNameAsync(userName);
            IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok();
        }

        private async Task CreateAdminAndGuest()
        {
            IdentityUser adminUser = await _userManager.FindByNameAsync("admin@gmail.com");
            if (adminUser != null) return;
            adminUser = new() {
                Email = "admin@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "admin@gmail.com"
            };

            IdentityResult result = await _userManager.CreateAsync(adminUser, "5Admin@gmail.com");
            if (!result.Succeeded) return;

            if (!await _roleManager.RoleExistsAsync("AdminRole")) await _roleManager.CreateAsync(new IdentityRole("AdminRole"));
            if (!await _roleManager.RoleExistsAsync("GuestRole")) await _roleManager.CreateAsync(new IdentityRole("GuestRole"));


            if (await _roleManager.RoleExistsAsync("AdminRole"))
            {
                await _userManager.AddToRoleAsync(adminUser, "AdminRole");
            }

            IdentityUser guestUser = await _userManager.FindByNameAsync("guest@gmail.com");
            if (guestUser != null) return;
            guestUser = new() {
                Email = "guest@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "guest@gmail.com"
            };
            result = await _userManager.CreateAsync(guestUser, "5Guest@gmail.com");
            if (!result.Succeeded) return;

            if (await _roleManager.RoleExistsAsync("GuestRole"))
            {
                await _userManager.AddToRoleAsync(guestUser, "GuestRole");
            }
        }

    }
}


