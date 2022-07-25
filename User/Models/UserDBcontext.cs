using Microsoft.EntityFrameworkCore;
using User.Models;
using CabInventoryManagement.Models;

namespace CabInventoryManagement.Models
{
    public class UserDBcontext : DbContext
    {

        public UserDBcontext(DbContextOptions<UserDBcontext>options) : base(options)
        {

        }

       public  DbSet<UserModel> Users { get; set; }

       public DbSet<Booking> Booking { get; set; }
       public DbSet<RouteDetails> RouteDetails { get; set; }
      

    }
}
