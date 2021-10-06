using Microsoft.EntityFrameworkCore;

namespace Common
{
    public class SakilaContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Film> Films { get; set; }
        
        public SakilaContext(DbContextOptions<SakilaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<FilmActor>(entity =>
            {
                entity.HasKey(e => new {e.ActorId, e.FilmId});
            });

            model.Entity<FilmCategory>(entity =>
            {
                entity.HasKey(e => new {e.FilmId, e.CategoryId});
            });
        }
    }
}