using System;
using System.Collections.Generic;
using System.Text;
using Exercicio_14.Domain.Entities;

namespace Exercicio_14.Application.Interfaces
{
    public interface IGadoService
    {
        void PreencherCampoAbate(Gado[] gado);
        double CalcularTotalLeite(Gado[] gado, bool posAbate = false);
        double CalcularTotalAlimento(Gado[] gado, bool posAbate = false);
        int ContarGadoParaAbate(Gado[] gado);
    }
}

