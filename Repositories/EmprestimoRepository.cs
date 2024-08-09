using emprestimo_livro.Database;
using emprestimo_livro.Models;
using emprestimo_livro.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace emprestimo_livro.Repositories {

    public class EmprestimoRepository : IEmprestimoRepository {

        private readonly EmprestimoDbContext _dbContext;

        public EmprestimoRepository(EmprestimoDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<List<Emprestimo>> GetByUser(int id) {
            return await _dbContext.Emprestimos
                .Where(x => x.ClienteId == id)
                .Include(livro => livro.Livro)
                .ToListAsync();
        }


        public async Task<Emprestimo> Create(Emprestimo emprestimo) {
            await _dbContext.Emprestimos.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();
            
            return emprestimo;
        }
    }
}