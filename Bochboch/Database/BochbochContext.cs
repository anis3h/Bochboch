using Bochboch.Models;
using Microsoft.EntityFrameworkCore;

namespace Bochboch.Database
{
    public class BochbochContext : DbContext
    {
        public DbSet<Rectangle> Rectangles { get; set; }

        public BochbochContext(DbContextOptions<BochbochContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
