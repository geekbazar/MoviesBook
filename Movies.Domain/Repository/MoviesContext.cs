using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Movies.Domain.Repository.Mapping;
using Movies.Domain.Model;

namespace Movies.Domain.Repository
{
    public partial class MoviesContext : DbContext
    {
        static MoviesContext()
        {
            Database.SetInitializer<MoviesContext>(null);
        }

        public MoviesContext()
            : base("Name=MoviesContext")
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MovieMap());
        }
    }
}
