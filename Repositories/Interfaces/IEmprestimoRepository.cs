using emprestimo_livro.Models;

namespace emprestimo_livro.Repositories.Interfaces {

    public interface IEmprestimoRepository {

        Task<List<Emprestimo>> GetByUser(int id);

        Task<Emprestimo> Create(Emprestimo emprestimo);
    }
}