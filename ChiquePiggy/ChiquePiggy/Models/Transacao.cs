using System;

namespace ChiquePiggy.Models.TransacaoModels
{
    public class Transacao
    {
        public int Id { get; set; }
        public int TotalPontos { get; set; }
        public int PontosDebitado { get; set; }
        public int PontosGanho { get; set; }
        public decimal ValorCompra { get; set; }
        public DateTime DataTransacao { get; set; } = DateTime.Now;
        public int IdCliente { get; set; }
        public char ResgatePremio { get; set; }

        public void RegastarPremio(char c)
        {
            if (c == 'S')
            {
                PontosDebitado = 100;
                TotalPontos = TotalPontos - PontosDebitado;
            }
            else
            {
                PontosGanho = (int)Math.Ceiling(ValorCompra);
                TotalPontos = TotalPontos + PontosGanho;
            }
                
        }
        public void TrocaValorPorPontos(decimal d)
        {
            if(d > 0)
               TotalPontos = (int)Math.Ceiling(ValorCompra);
        }
        public string AvisarCliente(int i)
        {
            if (i >= 100)
                return "Cliente Possui pontos suficientes para resgate do prêmio";

            return i.ToString();
        }
        public void DobrarPontos(DateTime date)
        {

            switch ((int)date.DayOfWeek)
            {
                case 1:
                   TotalPontos = (int)Math.Ceiling(ValorCompra) * 2;
                    break;
                case 2:
                    TotalPontos = (int)Math.Ceiling(ValorCompra) * 2;
                    break;
                default:
                    TotalPontos = (int)Math.Ceiling(ValorCompra);
                    break;
            }
            
            
        }
    }
}
