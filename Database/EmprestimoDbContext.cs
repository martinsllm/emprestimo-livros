using emprestimo_livro.Models;
using Microsoft.EntityFrameworkCore;

namespace emprestimo_livro.Database {

    public class EmprestimoDbContext : DbContext {
        public EmprestimoDbContext(DbContextOptions<EmprestimoDbContext> options) 
        : base(options)  {}

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}