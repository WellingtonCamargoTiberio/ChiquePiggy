using ChiquePiggy.Models.ClienteModels;
using ChiquePiggy.Models.TransacaoModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChiquePiggy.Models.HistoricoModels

{

    public class HistoricoTransacao
    {
        public Guid Id { get; set; }
        public Cliente Cliente { get; set; }
        public Transacao Transacao { get; set; }
    }
}
