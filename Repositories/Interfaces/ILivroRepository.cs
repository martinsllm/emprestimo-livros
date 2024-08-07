using emprestimo_livro.Models;

namespace emprestimo_livro.Repositories.Interfaces {

    public interface ILivroRepository {

        Task<List<Livro>> Get();

        Task<Livro> GetById(int id);

        Task<Livro> Create(Livro livro);

        Task<Livro> Update(Livro livro, int id);

        Task<bool> Remove(int id);

    }

}