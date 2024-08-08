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
            Cliente? cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if(cliente == null) throw new Exception($"Usuário para o ID: {id} não foi encontrado!");

            return cliente;
        }

        public async Task<Cliente> Create(Cliente cliente) {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> Update(Cliente cliente, int id) {
            Cliente foundClient = await GetById(id);

            foundClient.Nome = cliente.Nome;
            foundClient.Email = cliente.Email;
            foundClient.Telefone = cliente.Telefone;

            _dbContext.Clientes.Update(foundClient);
            await _dbContext.SaveChangesAsync();
            
            return foundClient;
        }

        public async Task<bool> Remove(int id) {
            Cliente foundClient = await GetById(id);

            _dbContext.Clientes.Remove(foundClient);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        
    }

}