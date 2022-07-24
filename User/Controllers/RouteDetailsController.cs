using CabInventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CabInventoryManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RouteDetailsController : Controller
    {
        private readonly UserDBcontext _context;

        public RouteDetailsController(UserDBcontext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetRouteDetails")]
        public async Task<ActionResult<List<RouteDetailsController>>> GetRouteDetails()
        {
            return Ok(_context.RouteDetails.ToList());
        }

        [HttpGet]
        [Route("GetRouteDetails/{Onboarding}")]
        public async Task<ActionResult<RouteDetails>> GetRoutesByOnboarding(string onboarding)
        {
            if (onboarding == null)
            {
                return BadRequest(new { msg = "onboarding cannot not be null" });
            }

            var user = await _context.RouteDetails.FirstOrDefaultAsync(x => x.Onboarding == onboarding);

            if (user == null)
            {
                return NotFound(new { msg = $"Cannot find route with {onboarding}" });
            }
            return Ok(user);
        }


        [HttpPost]
        [Route("CreateRoutes"), Authorize(Roles = "admin")]
        public string CreateRoutes([FromBody] RouteDetails routeDetails)
        {

            try
            {
                _context.RouteDetails.Add(routeDetails);
                _context.SaveChangesAsync();
                return ("Route Added Successfully!!");
            }
            catch (Exception ex)
            {
                return "error Occurred";
            }
        }


        [HttpPut]
        [Route("UpdateRouteDetails"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<RouteDetails>> UpdateRoute(int id, [FromBody] RouteDetails routeDetails)
        {

            var update = await _context.RouteDetails.FirstOrDefaultAsync(x => x.id == id);

            update.Onboarding = routeDetails.Onboarding;
            update.Destination = routeDetails.Destination;
            update.TimeSlot = routeDetails.TimeSlot;
            update.NoOfAvailableCars = routeDetails.NoOfAvailableCars;
            await _context.SaveChangesAsync();
            return Ok(update);


        }

        [HttpDelete]
        [Route("DeleteRoutes/{id}"), Authorize(Roles = "Admin")]
        public string DeleteRoute(int id)
        {
            try
            {
                var route = _context.RouteDetails.Where(e => e.id == id).SingleOrDefault();
                _context.RouteDetails.Remove(route);
                _context.SaveChanges();

                return "Route with Id=" + id + " is deleted successfully";
            }
            catch (Exception ex)
            {
                return "Exception occurred: " + ex;
            }
        }

    }

}
