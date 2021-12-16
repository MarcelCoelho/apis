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
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        public readonly MeuDbContext _context;


        private readonly ILogger<ItemsController> _logger;

        public ItemsController(MeuDbContext context, ILogger<ItemsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            return await _context.Items.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Item>> GetItem(Item item)
        {
            var itemRecuperado = await _context.Items.FindAsync(item.Id);
            if (itemRecuperado == null)
                return NotFound();

            return itemRecuperado;
        }

        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            item.DataCriacao = DateTime.Now;
            item.DataModificacao = item.DataCriacao;

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        [HttpDelete]
        public async Task<ActionResult<Item>> DeleteItem(Item item)
        {
            var itemRecuperado = await _context.Items.FindAsync(item.Id);
            if (itemRecuperado == null)
                return NotFound();

            _context.Items.Remove(itemRecuperado);
            await _context.SaveChangesAsync();

            return item;
        }
    }
}
