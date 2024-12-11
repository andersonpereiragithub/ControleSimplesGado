using Application.Services;
using Exercicio_14.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EXERCICIO14.Application.Services.Interfaces
{
    public interface IGadoService
    {
        void PreencherCampoAbate(List<Gado> gado);
        LeiteReportResult CalcularTotalLeite(bool posAbate = false);
        AlimentoReportResult CalcularTotalAlimento(bool posAbate = false);
        GadosAbatidosReportResult ContarGadoParaAbate();
        int CalcularIdade(DateTime dataNascimento);

    }
}

