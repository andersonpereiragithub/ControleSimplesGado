using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Exercicio_14.Application.Interfaces;
using Exercicio_14.Domain.Entities;
using EXERCICIO14.Presentation.UI;
using Exercicio_14.Application.Services;
using System.Reflection.Emit;
using System.Globalization;

namespace Exercicio_14.Presentation.Handlers
{
    public class CadastroGadoHandler
    {
        private readonly IGadoService _gadoService;

        public CadastroGadoHandler(IGadoService gadoService)
        {
            _gadoService = gadoService;
        }

        public Gado ObterNovoGado()
        {
            var gado = new Gado();

            gado.Codigo = LerInteiro("Código");
            gado.Nome = LerString("Nome");
            gado.Leite = LerDouble("Leite");
            gado.Alimento = LerDouble("Alimento");

            string lerDataNascimento;
            bool sair = false;
            do
            {
                lerDataNascimento = LerString("DataNascimento[dd/MM/yyy]: ");

                if (DateTime.TryParseExact(lerDataNascimento, "dd/MM/yyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime dataNascimento))
                {
                    gado.Idade = _gadoService.CalcularIdade(dataNascimento);
                    sair = true;
                }
                else { Console.WriteLine("Data Inválida! Use dd/MM/yyyy."); }
            } while (sair == false);

            gado.DataNascimento = DateTime.Parse(lerDataNascimento);
            gado.DefinirAbate();

            return gado;
        }

        private int LerInteiro(string campo, int min = int.MinValue, int max = int.MaxValue)
        {
            int valor;
            while (true)
            {
                Console.Write($"{campo}: ");
                if (int.TryParse(Console.ReadLine(), out valor) && valor >= min && valor <= max)
                {
                    return valor;
                }
                Console.WriteLine($"Entrada inválida. Informe um valor inteiro entre {min} e {max}.");
            }
        }

        private double LerDouble(string campo)
        {
            double valor;
            while (true)
            {
                Console.Write($"{campo}: ");
                if (double.TryParse(Console.ReadLine(), out valor))
                {
                    return valor;
                }
                Console.WriteLine("Entrada inválida. Informe um valor numérico.");
            }
        }

        private string LerString(string campo)
        {
            Console.Write($"{campo}: ");
            return Console.ReadLine();
        }

        public void ListarGados()
        {
            List<Gado> gados = CarregarGadosDeJson();  // Carrega os gados do arquivo JSON

            if (gados.Count == 0)
            {
                Console.WriteLine("Nenhum gado cadastrado.");
            }
            else
            {
                TabelaConsole tabela = new TabelaConsole();
                tabela.DefinirCabecalho("ID", "NOME", "LEITE L", "ALIMENTO KG", "IDADE", "ABATE");

                foreach (var gado in gados)
                {
                    string id = gado.Codigo.ToString();
                    string nome = gado.Nome.ToString();
                    string leite = gado.Leite.ToString();
                    string alimento = gado.Alimento.ToString();
                    string idade = gado.Idade.ToString();
                    string abate = gado.Abate.ToString();

                    tabela.AdicionarLinha(id, nome, leite, alimento, idade, abate);
                }

                tabela.DesenharTabela();
            }
        }

        public void CadastrarNovoGado()
        {
            List<Gado> gados = CarregarGadosDeJson();
            Gado novoGado = ObterNovoGado();

            gados.Add(novoGado);

            SalvarGadosEmJson(gados);
        }
        public void DeletarGado(string nomeDeletar)
        {
            List<Gado> gados = CarregarGadosDeJson();

            var gadoIsOnList = gados.Find(g => g.Nome == nomeDeletar);
            
            if (gadoIsOnList != null && gadoIsOnList.Abate != "NÃO")
            {
                gados.Remove(gadoIsOnList);
            }
            else
            {
                throw new Exception($"  \u001b[31m[{gadoIsOnList.Nome}] não está Classificado para ABATE!\u001b[0m"); 
            }

            SalvarGadosEmJson(gados);
        }

        public void SalvarGadosEmJson(List<Gado> gados)
        {
            string jsonString = JsonSerializer.Serialize(gados);
            File.WriteAllText("dadosGados.json", jsonString);
        }

        public static List<Gado> CarregarGadosDeJson()
        {
            if (File.Exists("dadosGados.json"))
            {
                string jsonString = File.ReadAllText("dadosGados.json");
                return JsonSerializer.Deserialize<List<Gado>>(jsonString);
            }
            return new List<Gado>();
        }

        public void ImprimirRelatorioLeite(bool aposAbate)
        {
            var resultadoRelatorio = _gadoService.CalcularTotalLeite(aposAbate);
            TabelaConsole tabela = new TabelaConsole();

            Console.WriteLine($"Total de leite {(aposAbate ? "após abate" : "")}: {resultadoRelatorio.TotalLeite} litros");

            if (resultadoRelatorio.GadosNaoAbatidos.Count > 0)
            {
                Console.WriteLine("\nLista de Gados Não Abatidos:");
                tabela.DefinirCabecalho("NOME", "LEITE");

                foreach (var gado in resultadoRelatorio.GadosNaoAbatidos)
                {
                    string nome = gado.Nome.ToString();
                    string leite = gado.Leite.ToString();

                    tabela.AdicionarLinha(nome, leite);
                }

                tabela.DesenharTabela();
            }
            else
            {
                Console.WriteLine("\nNenhum gado não abatido encontrado.");
            }
        }
        public void ImprimirRelatorioAlimento(bool aposAbate)
        {
            var resultadoRelatorio = _gadoService.CalcularTotalAlimento(aposAbate);
            TabelaConsole tabela = new TabelaConsole();

            Console.WriteLine($"Total de alimento {(aposAbate ? "após abate" : "")}: {resultadoRelatorio.TotalAlimento} alimentos");

            if (resultadoRelatorio.GadosNaoAbatidos.Count > 0)
            {
                Console.WriteLine("\nLista de consumo dos Gados");
                tabela.DefinirCabecalho("NOME", "ALIMENTO");

                foreach (var gado in resultadoRelatorio.GadosNaoAbatidos)
                {
                    string nome = gado.Nome.ToString();
                    string alimento = gado.Alimento.ToString();

                    tabela.AdicionarLinha(nome, alimento);
                }

                tabela.DesenharTabela();
            }
            else
            {
                Console.WriteLine("\nNenhum gado não abatido encontrado.");
            }
        }
        public void ImprimirRelatorioAbate()
        {
            var resultadoRelatorio = _gadoService.ContarGadoParaAbate();
            var totalAbatidos = 0;

            TabelaConsole tabela = new TabelaConsole();

            Console.WriteLine($"Total de Gados são {resultadoRelatorio.TotalAbatido} ABATIDOS.");

            if (resultadoRelatorio.GadosAbatidos.Count > 0)
            {
                Console.WriteLine("\nLista de Gados ABATIDOS");
                tabela.DefinirCabecalho("NOME");

                foreach (var gado in resultadoRelatorio.GadosAbatidos)
                {
                    string nome = gado.Nome.ToString();
                    tabela.AdicionarLinha(nome);
                }

                tabela.DesenharTabela();
            }
            else
            {
                Console.WriteLine("\nNenhum gado não abatido encontrado.");
            }
        }
    }
}
