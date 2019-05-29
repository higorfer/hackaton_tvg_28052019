using Empresa.Sistema.Infra.Model;
using Microsoft.EntityFrameworkCore;
using RAG.Treinamentos.Model;

namespace Empresa.Sistema.Infra.DataAccessMySqlProvider.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Curso> Cursos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Matricula>()
           .HasKey(bc => bc.Id);


            modelBuilder.Entity<Matricula>()
                .HasOne(bc => bc.Curso)
                .WithMany(b => b.Matriculas)
                .HasForeignKey(bc => bc.IdCurso);

            modelBuilder.Entity<Matricula>()
                .HasOne(bc => bc.Aluno)
                .WithMany(c => c.Matriculas)
                .HasForeignKey(bc => bc.IdAluno);
        }


    }
}


