using ChiquePiggy.Models.ClienteModels;
using ChiquePiggy.Models.HistoricoModels;
using ChiquePiggy.Models.TransacaoModels;
using Microsoft.EntityFrameworkCore;

namespace ChiquePiggy.Data.ApplicationDbContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public  DbSet<Cliente> Cliente { get; set; }
        public  DbSet<HistoricoTransacao>Historico{ get; set; } 
        public DbSet<Transacao> Transacao { get; set; }


    }
}
