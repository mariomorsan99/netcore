using Dominio;
using Microsoft.EntityFrameworkCore;



namespace Persistencia
{
    public class CursosOnlineContext: DbContext
    {
        public CursosOnlineContext(DbContextOptions option):base(option) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<CursoInstructor>().HasKey(ci=> new { ci.InstructorId, ci.CursoId});
        }


        public DbSet<Curso> Curso{get; set;}

        public DbSet<Comentario> Comentarios{get; set;}

        public DbSet<CursoInstructor> CursoInstructor{get; set;}

        public DbSet<Instructor> Instructor{get;set;}

        public DbSet<Precio> Precio{get; set;}



    }
}