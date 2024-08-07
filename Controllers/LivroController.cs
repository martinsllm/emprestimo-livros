using emprestimo_livro.Models;
using emprestimo_livro.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace emprestimo_livro.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase {

        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository) {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Livro>>> Get() {
            List<Livro> livros = await _livroRepository.Get();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetById(int id) {
            Livro livro = await _livroRepository.GetById(id);
            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> Create([FromBody] Livro livroBody) {
            Livro livro = await _livroRepository.Create(livroBody);
            return Ok(livro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> Update([FromBody] Livro livroBody, int id) {
            Livro livro = await _livroRepository.Update(livroBody, id);
            return Ok(livro);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remove(int id) {
            await _livroRepository.Remove(id);
            return NoContent();
        }


    }
}