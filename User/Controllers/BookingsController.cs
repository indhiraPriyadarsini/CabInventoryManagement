using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CabInventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace CabInventoryManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingsController : Controller
    {
        private readonly UserDBcontext _context;

        public BookingsController(UserDBcontext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("Booking")]
        public async Task<ActionResult<Booking>> CabBooking([FromBody] Booking booking)
        {

            var user = _context.Users.Where(x => x.UserName == booking.Email);
            if (user != null)
            {

                _context.Booking.Add(booking);
                await _context.SaveChangesAsync();
                return Ok("Booking Successfull");
            }
            else
            {
                return BadRequest("Booking Unsuccessfull");
            }

        }

    }
}
