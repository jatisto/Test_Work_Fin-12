using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test_work_fin_12.Models;

namespace test_work_fin_12.Data {
    public class AppDbContext : IdentityDbContext<User> {

        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) {
            Database.EnsureCreated ();
        }

    }
}