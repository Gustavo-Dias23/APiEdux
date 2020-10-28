using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoEdux.Domains;
using ProjetoEdux.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {

        TurmaRepositorie repo = new TurmaRepositorie();

        // GET: api/<TurmaController>
        [HttpGet]
        public List<Turma> Get()
        {
            return repo.ListarTodos();
        }

        // GET api/<TurmaController>/5
        [HttpGet("{id}")]
        public Turma Get(int Id)
        {
            return repo.BuscarPorID(Id);
        }

        // POST api/<TurmaController>
        [HttpPost]
        public Turma Post([FromBody] Turma a)
        {
            return repo.Cadastrar(a);
        }

        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        public Turma Put( [FromBody] Turma a, int id)
        {
            return repo.Alterar(a, id);
        }

        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        public Turma Delete([FromBody] Turma a, int id)
        {
            return repo.Excluir(a, id);
        }
    }
}
