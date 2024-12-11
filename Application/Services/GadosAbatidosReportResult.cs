using Exercicio_14.Domain.Entities;
using System.Collections.Generic;

namespace EXERCICIO14.Application.Services
{
    public class GadosAbatidosReportResult
    {
        public double TotalAbatido { get; set; }
        public List<Gado> GadosAbatidos { get; set; }

        public GadosAbatidosReportResult(double totalAbatido, List<Gado> gadosAbatidos)
        {
            TotalAbatido = totalAbatido;
            GadosAbatidos = gadosAbatidos;
        }
    }
}
