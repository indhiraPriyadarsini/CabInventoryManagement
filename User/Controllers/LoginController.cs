using CabInventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using User.Models;
using bcrypt = BCrypt.Net.BCrypt;

namespace CabInventoryManagement.Controllers
{
  
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserDBcontext _context;

        public LoginController(IConfiguration configuration, UserDBcontext context)
        {
            _configuration = configuration;
            _context = context;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Login>> Login([FromBody] Login login)
        {
            var DbUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email);
            if (DbUser != null)
            {
                if (!(bcrypt.Verify(login.Password, DbUser.Password)))
                {
                    return BadRequest("Password Incorrect");
                }
                else
                {
                    var Token = CreateToken(DbUser);
                    return Ok(Token);
                }

            }
            else
            {
                return BadRequest("User doesnot exists");
            }
        }


        private string CreateToken(UserModel user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("SecretKey:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
