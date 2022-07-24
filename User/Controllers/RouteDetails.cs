using CabInventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace CabInventoryManagement.Controllers
{

    public class RouteDetails : Controller
    {
        private readonly UserDBcontext _context;

        public RouteDetails(UserDBcontext context)
        {
            _context = context;
        }
    }
}
