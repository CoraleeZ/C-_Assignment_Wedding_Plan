using Microsoft.EntityFrameworkCore;

namespace Wedding_Planner.Models
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Useres { get; set; }
        public DbSet<WeddingPlan> WeddingPlanes { get; set; }
        public DbSet<Resevation> Resevationes { get; set; }
    }
}