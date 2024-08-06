using emprestimo_livro.Models;
using emprestimo_livro.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace emprestimo_livro.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase {

        private readonly IClienteRepository _clientRepository;

        public ClienteController(IClienteRepository clientRepository) {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get() {
            List<Cliente> clientes = await _clientRepository.Get();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id) {
            Cliente cliente = await _clientRepository.GetById(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create([FromBody] Cliente clienteBody) {
            Cliente cliente = await _clientRepository.Create(clienteBody);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> Update([FromBody] Cliente clienteBody, int id) {
            Cliente cliente = await _clientRepository.Update(clienteBody, id);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remove(int id) {
            await _clientRepository.Remove(id);
            return Ok();
        }

    }
}