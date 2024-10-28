using Exercicio_14.Domain.Entities;
using System.Collections.Generic;
using Exercicio_14.Application.Services;

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
