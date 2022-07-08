global using Microsoft.EntityFrameworkCore;

namespace MinimalAPITeloenseno
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<PersonaCurso> PersonaCurso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonaCurso>().HasKey(pc => new { pc.PersonaID, pc.CursoId });
        }




    }
}
