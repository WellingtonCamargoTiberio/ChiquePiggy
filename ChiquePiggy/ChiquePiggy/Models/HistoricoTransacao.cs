using System.ComponentModel.DataAnnotations;

namespace ChiquePiggy.Models.HistoricoModels

{

    public class HistoricoTransacao
    {
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdTransacao { get; set; }
    }
}
