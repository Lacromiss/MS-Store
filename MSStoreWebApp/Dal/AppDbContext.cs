using Microsoft.EntityFrameworkCore;
using MSStoreWebApp.Models;

namespace MSStoreWebApp.Dal
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<Steller> stellers { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<Catagory> catagories { get; set; }
        public DbSet<Gender> genders { get; set; }
        public DbSet<ColorProduct> colorProducts { get; set; }
        public DbSet<Best> bests { get; set; }
        public DbSet<Sik> siks { get; set; }
        public DbSet<Got> gots { get; set; }
        public DbSet<SikGot> sikGots { get; set; }
    }
}
