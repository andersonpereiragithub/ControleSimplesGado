using Application.Services;
using Exercicio_14.Domain.Entities;
using Exercicio_14.Presentation.Handlers;
using EXERCICIO14.Application.Services;
using EXERCICIO14.Application.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Exercicio_14.Application.Services
{
    public class GadoService : IGadoService
    {
        public void PreencherCampoAbate(List<Gado> gado)
        {
            foreach (var g in gado)
            {
                g.DefinirAbate();
            }
        }

        public LeiteReportResult CalcularTotalLeite(bool posAbate = false)
        {
            List<Gado> gados = CadastroGadoHandler.CarregarGadosDeJson();

            double totalLeite = 0;
            var gadosNaoAbatidos = new List<Gado>();

            foreach (var g in gados)
            {
                if (!posAbate || g.Abate == "NÃO")
                {
                    totalLeite += g.Leite;
                    gadosNaoAbatidos.Add(g);
                }
            }
            return new LeiteReportResult(totalLeite, gadosNaoAbatidos);
        }

        public AlimentoReportResult CalcularTotalAlimento(bool posAbate = false)
        {
            List<Gado> gados = CadastroGadoHandler.CarregarGadosDeJson();

            double totalAlimento = 0;
            var gadosNaoAbatidos = new List<Gado>();

            foreach (var g in gados)
            {
                if (!posAbate || g.Abate == "NÃO")
                {
                    totalAlimento += g.Alimento;
                    gadosNaoAbatidos.Add(g);
                }
            }
            return new AlimentoReportResult(totalAlimento, gadosNaoAbatidos);
        }

        public GadosAbatidosReportResult ContarGadoParaAbate()
        {
            List<Gado> gados = CadastroGadoHandler.CarregarGadosDeJson();

            int totalAbate = 0;
            var gadosAbatidos = new List<Gado>();

            foreach (var g in gados)
            {
                if (g.Abate == "SIM")
                {
                    totalAbate++;
                    gadosAbatidos.Add(g);
                }
            }
            return new GadosAbatidosReportResult(totalAbate, gadosAbatidos);
        }

        public int CalcularIdade(DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - dataNascimento.Year;

            if (dataNascimento > hoje.AddYears(-idade))
            {
                idade--;
            }
            return idade;
        }
    }
}
