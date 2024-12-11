using Exercicio_14.Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public class LeiteReportResult
    {
        public double TotalLeite { get; set; }
        public List<Gado> GadosNaoAbatidos { get; set; }

        public LeiteReportResult(double totalLeite, List<Gado> gadosNaoAbatidos)
        {
            TotalLeite = totalLeite;
            GadosNaoAbatidos = gadosNaoAbatidos;
        }
    }
}
