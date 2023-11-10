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
        public async Task<ActionResult<HistoricoTransacao>> Historico()
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
        public async Task<ActionResult<HistoricoTransacao>> GetCliente(string cpf)
        {
            try
            {
                var historico = await _context.Historico.Where(a => a.Cliente.Cpf == cpf).ToListAsync();

                return Json(historico);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

    }
}