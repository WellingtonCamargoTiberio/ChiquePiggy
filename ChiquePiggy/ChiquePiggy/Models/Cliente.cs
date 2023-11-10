using ChiquePiggy.Models.HistoricoModels;
using ChiquePiggy.Models.TransacaoModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChiquePiggy.Models.ClienteModels
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
    }
}
