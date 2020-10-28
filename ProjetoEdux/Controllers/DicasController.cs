using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEdux.Contexts;
using ProjetoEdux.Domains;
using ProjetoEdux.Utils;
using ProjetoEdux.Repositories;

namespace ProjetoEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicasController : ControllerBase
    {
        private readonly EduxContext _context;

        DicasRepositores repo = new DicasRepositores();

        public DicasController(EduxContext context)
        {
            _context = context;
        }

        // GET: api/Dicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dica>>> GetDica()
        {
            return await _context.Dica.ToListAsync();
        }

        // GET: api/Dicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dica>> GetDica(int id)
        {
            var dica = await _context.Dica.FindAsync(id);

            if (dica == null)
            {
                return NotFound();
            }

            return dica;
        }

        // PUT: api/Dicas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDica(int id, Dica dica)
        {
            if (id != dica.IdDica)
            {
                return BadRequest();
            }

            _context.Entry(dica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DicaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dicas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dica>> PostDica([FromBody][FromForm]Dica a)
        {
            if (Dica.imagem123 != null)
                {
           
            var urlImagem = Upload.Local(Dica.imagem123);
                Dica.URLImagem = urlImagem;

             }

            _context.Dica.Add(a);
            await _context.SaveChangesAsync();

            return repo.Cadastrar(a);
            }

        // DELETE: api/Dicas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dica>> DeleteDica(int id)
        {
            var dica = await _context.Dica.FindAsync(id);
            if (dica == null)
            { 
                return NotFound();
            }

            _context.Dica.Remove(dica);
            await _context.SaveChangesAsync();

            return dica;
        }

        private bool DicaExists(int id)
        {
            return _context.Dica.Any(e => e.IdDica == id);
        }
    }
}
