using emprestimo_livro.Models;

namespace emprestimo_livro.Repositories.Interfaces {

    public interface IClienteRepository {

        Task<List<Cliente>> Get();

        Task<Cliente> GetById(int id);

        Task<Cliente> Create(Cliente cliente);

        Task<Cliente> Update(Cliente cliente, int id);

        Task<bool> Remove(int id);
        
    }
}