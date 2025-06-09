namespace dapperCrud.Models
{
    public class Caixa
    {
        public DateTime DataTransacao { get; set; }
        public double ValorRecebido { get; set; }
        public double InicioCaixa { get; set; }
        public double FinalizacaoCaixa { get; set; }

        public bool TransacaoEfetuada { get; set; }
    }
}
