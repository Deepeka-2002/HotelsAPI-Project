using Microsoft.EntityFrameworkCore;

namespace HotelsAPI.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) 
        { 

        }
        public DbSet<User> user { get; set; }

        public DbSet<Customer> customer { get; set; }
        public DbSet<Hotels> hotels { get; set; }
        public DbSet<Rooms> rooms { get; set; }
        public DbSet<Reservations> reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        internal Task Gethotels()
        {
            throw new NotImplementedException();
        }
    }
}
