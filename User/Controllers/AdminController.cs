
using CabInventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Models;

namespace CabInventoryManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly UserDBcontext _context;

        public AdminController(UserDBcontext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetUser/{id}"), Authorize(Roles = "admin")]
        public async Task<ActionResult<Object>> GetUserById(int id)
        {
            if (id == null || _context?.Users == null)
            {
                return BadRequest(new { msg = "Id cannot not be null" });
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (user == null)
            {
                return NotFound(new { msg = $"User not found with id {id}" });
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("GetUsers"), Authorize(Roles = "admin")]
        public IEnumerable<UserModel> GetUsers()
        {
            var users = _context.Users.Where(x => x.Role == "User");
            return (users);
        }

        [HttpGet]
        [Route("GetUserBookingDetails"), Authorize(Roles = "admin")]
        public async Task<ActionResult<List<Booking>>> GetBookedUsers()
        {
            return Ok(_context.Booking.ToList());
        }





    }
}
