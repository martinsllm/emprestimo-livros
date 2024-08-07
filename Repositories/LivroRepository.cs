using emprestimo_livro.Database;
using emprestimo_livro.Models;
using emprestimo_livro.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace emprestimo_livro.Repositories {

    public class LivroRepository : ILivroRepository {

        private readonly EmprestimoDbContext _dbContext;

        public LivroRepository(EmprestimoDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<List<Livro>> Get() {
            return await _dbContext.Livros.ToListAsync();
        }

        public async Task<Livro> GetById(int id) {
            Livro? livro = await _dbContext.Livros.FirstOrDefaultAsync(x => x.Id == id);

            if(livro == null) throw new Exception($"Livvro nº {id} não foi encontrado!");

            return livro;
        }

        public async Task<Livro> Create(Livro livro) {
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();

            return livro;
        }

        public async Task<Livro> Update(Livro livro, int id) {
            Livro foundBook = await GetById(id);

            foundBook.Nome = livro.Nome;
            foundBook.Autor = livro.Autor;
            foundBook.Editora = livro.Editora;
            foundBook.AnoPublicacao = livro.AnoPublicacao;

            _dbContext.Livros.Update(foundBook);
            await _dbContext.SaveChangesAsync();

            return livro;
        }

        public async Task<bool> Remove(int id) {
            Livro foundBook = await GetById(id);

            _dbContext.Livros.Remove(foundBook);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }
    }
}