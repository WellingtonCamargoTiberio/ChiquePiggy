﻿namespace DKP.Models
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<Agendamento> Agendamentos { get; set; }

    }
}
