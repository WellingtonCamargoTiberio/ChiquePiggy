using ChiquePiggy.Models.ClienteModels;
using System;

namespace ChiquePiggy.Models.TransacaoModels
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public int TotalPontos { get; set; }
        public int PontosDebitado { get; set; }
        public int PontosGanho { get; set; }
        public decimal ValorCompra { get; set; }
        public DateTime DataTransacao { get; set; } = DateTime.Now;
        public Cliente Cliente { get; set; }
        public char ResgatePremio { get; set; }

        public void RegastarPremio(int pontos)
        {
                TotalPontos -= pontos;
        }
        public void TrocaValorPorPontos(decimal real)
        {
            if (real > 0)
                TotalPontos = (int)Math.Ceiling(real);
        }
        public string AvisarCliente(int pontos)
        {
            if (pontos >= 100)
                return "Cliente Possui pontos suficientes para resgate do prêmio";

            return pontos.ToString();
        }
        public void DobrarPontos(DateTime dataTransacao, decimal real)
        {

            switch ((int)dataTransacao.DayOfWeek)
            {
                case 1:
                    TotalPontos = (int)Math.Ceiling(real) * 2;
                    break;
                case 2:
                    TotalPontos = (int)Math.Ceiling(real) * 2;
                    break;
                default:
                    TotalPontos = (int)Math.Ceiling(real);
                    break;
            }


        }
    }
}
