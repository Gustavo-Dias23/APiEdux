using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoEdux.Contexts;
using ProjetoEdux.Domains;
using ProjetoEdux.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorturmaController : ControllerBase
    {


        ProfessorTurmaRepositorie repo = new ProfessorTurmaRepositorie();

        // GET: api/<ProfessorturmaController>
        [HttpGet]
        public List<Professorturma> Get()
        {
            return repo.ListarTodos();
        }

        // GET api/<ProfessorturmaController>/5
        [HttpGet("{id}")]
        public Professorturma Get(int Id)
        {
            return repo.BuscarPorID(Id);
        }

        // POST api/<ProfessorturmaController>
        [HttpPost]
        public Professorturma Post([FromBody] Professorturma a)
        {
            return repo.Cadastrar(a);
        }

        // PUT api/<ProfessorturmaController>/5
        [HttpPut("{id}")]
        public Professorturma Put(int id, [FromBody] Professorturma a)
        {
            return repo.Alterar(a, id);
        }

        // DELETE api/<ProfessorturmaController>/5
        [HttpDelete("{id}")]
        public Professorturma Delete(int id, [FromBody] Professorturma a)
        {
            return repo.Excluir(a, id);
        }
    }
}
