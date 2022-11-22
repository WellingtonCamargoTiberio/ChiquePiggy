using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChiquePiggy.Data.ApplicationDbContext;
using ChiquePiggy.Models.TransacaoModels;
using ChiquePiggy.Models.HistoricoModels;

namespace ChiquePiggy.Controllers.TrnsacoesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransacoesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetTransacoes()
        {
            try
            {
                var result = _context.Transacao.ToList();

                return Json(result);
            }
            catch
            {
                return BadRequest("Banco de dados falhou");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Transacao>> GetTransacao(int id)
        {
            try
            {
                var transacao = await _context.Transacao.FindAsync(id);

                if (transacao == null)
                {
                    return NotFound();
                }

                return transacao;
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Transacao>> PostTodoItem(Transacao transacao)
        {
            try
                 
            {
                _context.Transacao.Add(transacao);
                await _context.SaveChangesAsync();
                if (ClienteExiste(transacao.IdCliente))
                {
                    var clientes = await _context.Cliente.Where(a => a.Id == transacao.IdCliente)
                    .Join(_context.Transacao,
                    a => a.Id,
                    b => b.IdCliente,
                    (a, b) => new { a, b })
                    .GroupBy(p => new { p.b.IdCliente })
                    .Select(x => new
                    {
                        pontos = x.Sum(a => a.b.TotalPontos),
                    }).ToListAsync();
                    
                    transacao.TrocaValorPorPontos(transacao.ValorCompra);
                    transacao.DobrarPontos(transacao.DataTransacao);
                    transacao.RegastarPremio(transacao.ResgatePremio);
  
                }

                HistoricoTransacao h = new HistoricoTransacao();
                h.IdCliente = transacao.IdCliente;
                h.IdTransacao = transacao.Id;
                _context.Historico.Add(h);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTransacao), new { id = transacao.Id }, transacao);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }
        private bool ClienteExiste(int id)
        {
            return _context.Transacao.Any(e => e.IdCliente == id);
        }
    }
}
