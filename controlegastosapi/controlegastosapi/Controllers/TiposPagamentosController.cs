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
    [Route("api/tipospagamentos")]
    public class TiposPagamentosController : ControllerBase
    {
        public readonly MeuDbContext _context;

        private readonly ILogger<TiposPagamentosController> _logger;

        public TiposPagamentosController(MeuDbContext context, ILogger<TiposPagamentosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoPagamento>> Get()
        {
            return await _context.TiposPagamentos.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<TipoPagamento>> GetTipoPagamento(TipoPagamento tipoPagamento)
        {
            var tipoPagamentoRecuperado = await _context.TiposPagamentos.FindAsync(tipoPagamento.Id);
            if (tipoPagamentoRecuperado == null)
                return NotFound();

            return tipoPagamentoRecuperado;
        }

        [HttpPost]
        public async Task<ActionResult<TipoPagamento>> PostTipoPagamento(TipoPagamento tipoPagamento)
        {
            tipoPagamento.DataCriacao = DateTime.Now;
            tipoPagamento.DataModificacao = tipoPagamento.DataCriacao;

            _context.TiposPagamentos.Add(tipoPagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPagamento", new { id = tipoPagamento.Id }, tipoPagamento);
        }

        [HttpDelete]
        public async Task<ActionResult<TipoPagamento>> DeleteTipoPagamento(TipoPagamento tipoPagamento)
        {
            var tipoPagamentoRecuperado = await _context.TiposPagamentos.FindAsync(tipoPagamento.Id);
            if (tipoPagamentoRecuperado == null)
                return NotFound();

            _context.TiposPagamentos.Remove(tipoPagamentoRecuperado);
            await _context.SaveChangesAsync();

            return tipoPagamento;
        }
    }
}
