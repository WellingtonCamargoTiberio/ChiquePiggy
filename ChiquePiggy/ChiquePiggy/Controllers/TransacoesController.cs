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
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost("PontuarCliente")]
        public async Task<ActionResult<Transacao>> PontuarCliente(string cpf, decimal valorReal)
        {
            try

            {
                var cliente = await _context.Cliente.Where(c => c.Cpf == cpf).FirstOrDefaultAsync();
                var transacao = new Transacao();

                if (ClienteExiste(cliente.Cpf))
                {
                    transacao.Cliente = cliente;
                    transacao.TrocaValorPorPontos(valorReal);
                    transacao.DobrarPontos(transacao.DataTransacao, valorReal);
                    _context.Transacao.Add(transacao);
                    await _context.SaveChangesAsync();
                }
                else
                    return Json("Cliente não encontrado");

                transacao.AvisarCliente(transacao.TotalPontos);

                return CreatedAtAction(nameof(GetTransacao), new { id = transacao.Id }, transacao);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPost("ResgatePremio")]
        public async Task<ActionResult<Transacao>> ResgatePremio(string cpf, bool resgate, int pontosResgate)
        {
            try

            {
                var transacao = await _context.Transacao.Where(a => a.Cliente.Cpf == cpf).FirstOrDefaultAsync();

                if (resgate == true)
                {
                    if (transacao.TotalPontos > pontosResgate)
                        transacao.RegastarPremio(pontosResgate);
                    else
                        return Json("Você não tem saldo para fazer o resgate");

                    _context.Transacao.Update(transacao);
                    await _context.SaveChangesAsync();
                }

                return CreatedAtAction(nameof(GetTransacao), new { id = transacao.Id }, transacao);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        private bool ClienteExiste(string cpf)
        {
            return _context.Cliente.Any(e => e.Cpf == cpf);
        }
    }
}
