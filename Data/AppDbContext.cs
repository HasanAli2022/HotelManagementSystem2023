using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<RoomDetails> RoomDetails { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

    }
}
