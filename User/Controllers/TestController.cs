using CabInventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CabInventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly UserDBcontext _context;
        public TestController(UserDBcontext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetUsers")]
        public IEnumerable<testClass> GetUsers()
        {
            var users = _context.testClass.ToList();
            return (users);
        }

        [HttpPost]
        [Route("test") ]
        public string CreateRoutes([FromBody] testClass test)
        {

            try
            {
                _context.testClass.Add(test);
                _context.SaveChangesAsync();
                return ("test Successful!!");
            }
            catch (Exception ex)
            {
                return "error Occurred";
            }
        }
    }


}
