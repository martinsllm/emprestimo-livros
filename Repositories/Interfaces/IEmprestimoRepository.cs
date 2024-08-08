using emprestimo_livro.Models;

namespace emprestimo_livro.Repositories.Interfaces {

    public interface IEmprestimoRepository {

        Task<Emprestimo> Create(Emprestimo emprestimo);
    }
}