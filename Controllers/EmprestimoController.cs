using emprestimo_livro.Models;
using emprestimo_livro.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace emprestimo_livro.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase {

        private readonly IEmprestimoRepository _emprestimoRepository;

        public EmprestimoController(IEmprestimoRepository emprestimoRepository){
            _emprestimoRepository = emprestimoRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Emprestimo>>> GetByUser(int id) {
            List<Emprestimo> emprestimos = await _emprestimoRepository.GetByUser(id);
            return Ok(emprestimos);
        }

        [HttpPost]
        public async Task<ActionResult<Emprestimo>> Create([FromBody] Emprestimo emprestimoBody) {
            Emprestimo emprestimo = await _emprestimoRepository.Create(emprestimoBody);
            return Ok(emprestimo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remove(int id) {
            await _emprestimoRepository.Remove(id);
            return NoContent();
        }

    }
}