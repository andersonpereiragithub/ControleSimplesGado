using Exercicio_14.Domain.Entities;
using System.Collections.Generic;

namespace EXERCICIO14.Application.Services
{
    public class AlimentoReportResult
    {
        public double TotalAlimento { get; set; }
        public List<Gado> GadosNaoAbatidos { get; set; }

        public AlimentoReportResult(double totalAlimento, List<Gado> gadosNaoAbatidos)
        {
            TotalAlimento = totalAlimento;
            GadosNaoAbatidos = gadosNaoAbatidos;
        }
    }
}
