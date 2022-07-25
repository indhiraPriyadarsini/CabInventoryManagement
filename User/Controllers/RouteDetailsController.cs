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
        [Route("CreateRoutes")]
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
        [Route("UpdateRouteDetails/{id}"), Authorize(Roles = "admin")]
        public string updateStatus([FromBody] RouteDetails routeDetails, int? id)
        {
            try
            {
                var updateStatus = _context.RouteDetails.Where(e => e.id == id).SingleOrDefault();

                updateStatus.Onboarding = routeDetails.Onboarding;
                _context.SaveChanges();
                //Send.Producer(status.Status);
                return "Location id " + updateStatus.id + " Is Being Updated";
            }

            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }

        }

    }

}
