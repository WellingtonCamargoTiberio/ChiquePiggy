using ChiquePiggy.Data.ApplicationDbContext;
using ChiquePiggy.Models.HistoricoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiquePiggy.Controllers.HistoricoController
{

    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoricoController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<HistoricoTransacao>> Clientes()
        {
            try
            {
                var result = await _context.Historico.ToListAsync();

                return Ok(result);
            }
            catch
            {
                return BadRequest("Banco de dados falhou");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoTransacao>> GetCliente(int id)
        {
            try
            {
                var historico = await _context.Historico.Where(a => a.IdCliente == id)
                 .Join(_context.Transacao,
                 a => a.IdCliente,
                 b => b.IdCliente,
                 (a, b) => new { a, b })
                 .Join(_context.Cliente,
                 b => b.b.IdCliente,
                 c => c.Id,
                 (b, c) => new { b, c })
                 .GroupBy(p => new { p.b.a.IdCliente, p.b.b.DataTransacao, p.c.Nome, p.c.Cpf, p.b.b.TotalPontos, p.b.b.PontosDebitado })
                 .Select(x => new
                 {
                   data =  x.Key.DataTransacao,
                   codCliente= x.Key.IdCliente,
                   nome = x.Key.Nome,
                   cpf = x.Key.Cpf,
                   pontos = x.Key.TotalPontos,
                   pontosDebitado = x.Key.PontosDebitado

                     
                 }).ToListAsync();


                return Json(historico);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

    }
}