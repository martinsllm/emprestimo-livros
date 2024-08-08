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

        [HttpPost]
        public async Task<ActionResult<Emprestimo>> Create([FromBody] Emprestimo emprestimoBody) {
            Emprestimo emprestimo = await _emprestimoRepository.Create(emprestimoBody);
            return Ok(emprestimo);
        }

    }
}