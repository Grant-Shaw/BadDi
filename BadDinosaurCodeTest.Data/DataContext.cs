using BadDinosaurCodeTest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BadDinosaurCodeTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dinosaur> Dinosaurs { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
