using System;
using System.Collections.Generic;
using System.Text;
using Exercicio_14.Application.Interfaces;
using Exercicio_14.Domain.Entities;

namespace Exercicio_14.Application.Services
{
    public class GadoService : IGadoService
    {
        public void PreencherCampoAbate(Gado[] gado)
        {
            foreach (var g in gado)
            {
                g.DefinirAbate();
            }
        }

        public double CalcularTotalLeite(Gado[] gado, bool posAbate = false)
        {
            double totalLeite = 0;
            foreach (var g in gado)
            {
                if (!posAbate || g.Abate == "NÃO")
                {
                    totalLeite += g.Leite;
                }
            }
            return totalLeite;
        }

        public double CalcularTotalAlimento(Gado[] gado, bool posAbate = false)
        {
            double totalAlimento = 0;
            foreach (var g in gado)
            {
                if (!posAbate || g.Abate == "NÃO")
                {
                    totalAlimento += g.Alimento;
                }
            }
            return totalAlimento;
        }

        public int ContarGadoParaAbate(Gado[] gado)
        {
            int total = 0;
            foreach (var g in gado)
            {
                if (g.Abate == "SIM")
                {
                    total++;
                }
            }
            return total;
        }
    }
}
