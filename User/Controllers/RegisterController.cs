using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CabInventoryManagement.Models;
using User.Models;
using bcrypt = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authorization;

namespace CabInventoryManagement.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly UserDBcontext _context;

        public RegisterController(UserDBcontext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel User)
        {
            var checkUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == User.Email);
            if (checkUser == null)
            {
                User.Password = bcrypt.HashPassword(User.Password, 12);
                _context.Users.Add(User);
                await _context.SaveChangesAsync();
                return Ok("User Registered successfully");
            }
            else
            {
                return BadRequest("User Already Exists");
            }
        }


    }
}