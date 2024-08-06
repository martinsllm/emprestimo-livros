using emprestimo_livro.Database;
using emprestimo_livro.Models;
using emprestimo_livro.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace emprestimo_livro.Repositories {

    public class ClienteRepository : IClienteRepository {

        private readonly EmprestimoDbContext _dbContext;

        public ClienteRepository(EmprestimoDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<List<Cliente>> Get() {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetById(int id) {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> Create(Cliente cliente) {
            await _dbContext.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public Task<Cliente> Update(Cliente cliente, int id) {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id) {
            throw new NotImplementedException();
        }
        
    }

}