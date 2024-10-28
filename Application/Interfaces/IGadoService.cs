using System;
using System.Collections.Generic;
using System.Text;
using Application.Services;
using Exercicio_14.Domain.Entities;

namespace Exercicio_14.Application.Interfaces
{
    public interface IGadoService
    {
        void PreencherCampoAbate(Gado[] gado);
        LeiteReportResult CalcularTotalLeite(bool posAbate = false);
        double CalcularTotalAlimento(bool posAbate = false);
        int ContarGadoParaAbate();
    }
}

