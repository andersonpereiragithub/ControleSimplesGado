using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Exercicio_14.Domain.Entities;
using EXERCICIO14.Presentation.UI;

namespace Exercicio_14.Presentation.Handlers
{
    public class CadastroGadoHandler
    {
        public Gado ObterNovoGado()
        {
            var gado = new Gado();

            gado.Codigo = LerInteiro("Código");
            gado.Nome = LerString("Nome");
            gado.Leite = LerDouble("Leite");
            gado.Alimento = LerDouble("Alimento");

            int mesNasc = LerInteiro("Mês de nascimento", 1, 12);
            int anoNasc = LerInteiro("Ano de nascimento", 1900, DateTime.Now.Year);

            gado.DefinirAbate();
            gado.CalcularIdade(mesNasc, anoNasc, DateTime.Now.Month, DateTime.Now.Year);

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
            List<Gado> gados = CarregarGadosDeJson();  // Carrega gados existentes
            Gado novoGado = ObterNovoGado();           // Cadastra um novo gado

            gados.Add(novoGado);                       // Adiciona à lista de gados

            SalvarGadosEmJson(gados);                  // Salva a lista atualizada no arquivo JSON
        }

        // Método para salvar a lista de gados em um arquivo JSON
        public void SalvarGadosEmJson(List<Gado> gados)
        {
            string jsonString = JsonSerializer.Serialize(gados);
            File.WriteAllText("dadosGados.json", jsonString);
        }

        // Método para carregar os gados de um arquivo JSON
        public static List<Gado> CarregarGadosDeJson()
        {
            if (File.Exists("dadosGados.json"))
            {
                string jsonString = File.ReadAllText("dadosGados.json");
                return JsonSerializer.Deserialize<List<Gado>>(jsonString);
            }
            return new List<Gado>(); // Retorna lista vazia se o arquivo não existir
        }

    }
}
