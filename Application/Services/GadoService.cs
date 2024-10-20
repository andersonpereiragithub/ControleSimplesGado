﻿using System;
using System.Collections.Generic;
using System.Text;
using Exercicio_14.Application.Interfaces;
using Exercicio_14.Domain.Entities;
using Exercicio_14.Presentation.Handlers;

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

        public double CalcularTotalLeite(bool posAbate = false)
        {
            List<Gado> gados = CadastroGadoHandler.CarregarGadosDeJson();

            double totalLeite = 0;
            foreach (var g in gados)
            {
                if (!posAbate || g.Abate == "NÃO")
                {
                    totalLeite += g.Leite;
                }
            }
            return totalLeite;
        }

        public double CalcularTotalAlimento(bool posAbate = false)
        {
            List<Gado> gados = CadastroGadoHandler.CarregarGadosDeJson();

            double totalAlimento = 0;
            foreach (var g in gados)
            {
                if (!posAbate || g.Abate == "NÃO")
                {
                    totalAlimento += g.Alimento;
                }
            }
            return totalAlimento;
        }

        public int ContarGadoParaAbate()
        {
            List<Gado> gados = CadastroGadoHandler.CarregarGadosDeJson();

            int total = 0;
            foreach (var g in gados)
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
