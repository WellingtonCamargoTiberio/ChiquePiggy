namespace DKP.Models
{
    public class Agendamento
    { 
        public Guid Id { get; set; }
        
        public string Descricao { get; set; }
        public DateTime InicioAgendamento { get; set; }
        public DateTime TerminoAgendamento {  get; set; }
        public bool Concluido { get; set; }

    }
}
