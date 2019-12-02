using KnewinAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Knewin.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        public AuthenticateController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {

                    var authClaims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                    var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("eefdd744-f22d-4784-ac05-f9113435036a"));

                    var jwtToken = new JwtSecurityToken(
                        issuer: "knewin",
                        audience: "knewin",
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    var token = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                        expiration = jwtToken.ValidTo
                    };

                    return Ok(token);
                }

                return Unauthorized();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}