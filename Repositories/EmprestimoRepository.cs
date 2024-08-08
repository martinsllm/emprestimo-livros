using emprestimo_livro.Database;
using emprestimo_livro.Models;
using emprestimo_livro.Repositories.Interfaces;

namespace emprestimo_livro.Repositories {

    public class EmprestimoRepository : IEmprestimoRepository {

        private readonly EmprestimoDbContext _dbContext;

        public EmprestimoRepository(EmprestimoDbContext dbContext) {
            _dbContext = dbContext;
        }


        public async Task<Emprestimo> Create(Emprestimo emprestimo) {
            await _dbContext.Emprestimos.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();
            
            return emprestimo;
        }
    }
}