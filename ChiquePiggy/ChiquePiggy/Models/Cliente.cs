using System.ComponentModel.DataAnnotations;

namespace ChiquePiggy.Models.ClienteModels
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
    }
}
