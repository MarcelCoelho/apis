using controlegastosapi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace controlegastosapi.Controllers
{
    [ApiController]
    [Route("api/faturas")]
    public class FaturasController : ControllerBase
    {
        public readonly MeuDbContext _context;
        private readonly ILogger<FaturasController> _logger;

        public FaturasController(MeuDbContext context, ILogger<FaturasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Fatura>> Get()
        {
            return await _context.Faturas.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Fatura>> GetFatura(Fatura Fatura)
        {
            var FaturaRecuperada = await _context.Faturas.FindAsync(Fatura.Id);
            if (FaturaRecuperada == null)
                return NotFound();

            return FaturaRecuperada;
        }

        [HttpPost]
        public async Task<ActionResult<Fatura>> PostFatura(Fatura Fatura)
        {
            Fatura.DataCriacao = DateTime.Now;
            Fatura.DataModificacao = Fatura.DataCriacao;

            _context.Faturas.Add(Fatura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFatura", new { id = Fatura.Id }, Fatura);
        }

        [HttpDelete]
        public async Task<ActionResult<Fatura>> DeleteFatura(Fatura Fatura)
        {
            var FaturaRecuperada = await _context.Faturas.FindAsync(Fatura.Id);
            if (FaturaRecuperada == null)
                return NotFound();

            _context.Faturas.Remove(FaturaRecuperada);
            await _context.SaveChangesAsync();

            return Fatura;
        }
    }
}
