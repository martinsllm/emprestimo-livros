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

        public async Task<Emprestimo> GetById(int id) {
            Emprestimo? emprestimo = await _dbContext.Emprestimos.FirstOrDefaultAsync(x => x.Id == id);

            if(emprestimo == null) throw new Exception($"Empréstimo nº {id} não foi encontrado!");

            return emprestimo;
        }

        public async Task<Emprestimo> Create(Emprestimo emprestimo) {
            await _dbContext.Emprestimos.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();
            
            return emprestimo;
        }

        public async Task<bool> Remove(int id) {
            Emprestimo foundLoan = await GetById(id);

            _dbContext.Emprestimos.Remove(foundLoan);
            await _dbContext.SaveChangesAsync();

            return true;

        }
    }
}