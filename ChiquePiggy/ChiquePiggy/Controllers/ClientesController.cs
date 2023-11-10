using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChiquePiggy.Data.ApplicationDbContext;
using ChiquePiggy.Models.ClienteModels;

namespace ChiquePiggy.Controllers.ClientesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Cliente>> Clientes()
        {
            try
            {
                var result = await _context.Cliente.ToListAsync();

                return Ok(result);
            }
            catch
            {
                return BadRequest("Banco de dados falhou");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(string cpf)
        {
            try
            {
                var clientes = await _context.Cliente.Where(c => c.Cpf == cpf).ToListAsync();

                if (clientes == null)
                {
                    return NotFound();
                }

                return Json(clientes);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CriacaoCliente(Cliente cliente)
        {
            try
            {
                if (ClienteExiste(cliente.Cpf))
                    return BadRequest("Usuário já existe");
                else
                    _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();
                
                return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
                
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }

        private bool ClienteExiste(string cpf)
        {
            return _context.Cliente.Any(e => e.Cpf == cpf);
        }
    }
}
