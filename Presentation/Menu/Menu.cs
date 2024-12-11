using Exercicio_14.Domain.Entities;
using Exercicio_14.Presentation.Handlers;
using EXERCICIO14.Application.Services.Interfaces;
using EXERCICIO14.Presentation.Menu;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exercicio_14.Presentation.Menu
{
    public class Menu
    {
        private readonly IGadoService _gadoService;
        private readonly CadastroGadoHandler _cadastroGadoHandler;
        public List<Gado> listaDeGados = new List<Gado>();

        public Menu(IGadoService gadoService, CadastroGadoHandler cadastroGadoHandler)
        {
            _gadoService = gadoService ?? throw new ArgumentNullException(nameof(gadoService));
            _cadastroGadoHandler = cadastroGadoHandler ?? throw new ArgumentNullException(nameof(cadastroGadoHandler));
            InicializarAcoesMenu();
        }

        private Dictionary<char, Action> acoesMenu;

        private void InicializarAcoesMenu()
        {
            acoesMenu = new Dictionary<char, Action>
            {
                { (char)OpcaoMenu.CadastrarGado, InstanciarGados },
                { (char)OpcaoMenu.DeletarGado, DeletarGados },
                { (char)OpcaoMenu.EditarGado, AlterarDadosGado},
                { (char)OpcaoMenu.ListarCadastros, _cadastroGadoHandler.ListarGados },
                { (char)OpcaoMenu.RelatorioLeite, () => _cadastroGadoHandler.ImprimirRelatorioLeite(false) },
                { (char)OpcaoMenu.RelatorioAlimento, () => _cadastroGadoHandler.ImprimirRelatorioAlimento(false) },
                { (char)OpcaoMenu.RelatorioLeiteAposAbate, () => _cadastroGadoHandler.ImprimirRelatorioLeite(true) },
                { (char)OpcaoMenu.RelatorioAlimentoAposAbate, () => _cadastroGadoHandler.ImprimirRelatorioAlimento(true) },
                { (char)OpcaoMenu.GadosParaAbate, _cadastroGadoHandler.ImprimirRelatorioAbate }
            };
        }

        public void AbrirMenu()
        {
            char opcao;
            do
            {
                ExibirMenu();
                Console.Write("\u001b[31mOpção: \u001b[0m");
                opcao = Console.ReadLine().ToLower()[0];

                bool aOpcaoDoUsuarioExiste = acoesMenu.ContainsKey(opcao);

                if (aOpcaoDoUsuarioExiste)
                {
                    acoesMenu[opcao].Invoke();
                }
                else if (opcao != (char)OpcaoMenu.Sair)
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }

                if (opcao != (char)OpcaoMenu.Sair)
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }

            } while (opcao != (char)OpcaoMenu.Sair);
        }

        public void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("\n================= MENU =================\n");
            Console.WriteLine("(\u001b[31ma\u001b[0m) - Cadastrar Gado");
            Console.WriteLine("(\u001b[31mb\u001b[0m) - Deletar Gado");
            Console.WriteLine("(\u001b[31mc\u001b[0m) - Alterar Dados Gado");
            Console.WriteLine("      |-\u001b[33mImprimir Relatórios:\u001b[0m");
            Console.WriteLine("      |--(\u001b[31m1\u001b[0m) - Listar todos os Cadastros");
            Console.WriteLine("      |__(\u001b[31m2\u001b[0m) - Total de LEITE produzido");
            Console.WriteLine("      |__(\u001b[31m3\u001b[0m) - Total de LEITE após Abate");
            Console.WriteLine("      |__(\u001b[31m4\u001b[0m) - Total de ALIMENTO consumido");
            Console.WriteLine("      |__(\u001b[31m5\u001b[0m) - Total de ALIMENTO após Abate");
            Console.WriteLine("      |__(\u001b[31m6\u001b[0m) - Número de gados para ABATE\n");
            Console.WriteLine("(\u001b[31m0\u001b[0m) - Sair");
            Console.WriteLine("========================================\n");
        }

        private void InstanciarGados()
        {
            Console.WriteLine($"Cadastro do gado:");
            _cadastroGadoHandler.CadastrarNovoGado();
        }
        private void DeletarGados()
        {
            _cadastroGadoHandler.ListarGados();

            try
            {
                Console.Write($"  \u001b[31mDeletar gado:\u001b[0m ");
                string nomeGado = Console.ReadLine();

                _cadastroGadoHandler.DeletarGado(nomeGado);

                Console.WriteLine($" \u001b[32m[{nomeGado}] excluído com sucesso\u001b[0m");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AlterarDadosGado()
        {
            _cadastroGadoHandler.ListarGados();

            try
            {
                Console.Write($"  \u001b[31mEntre com o nome do Gado:\u001b[0m ");
                string nomeGado = Console.ReadLine();

                var gados = CadastroGadoHandler.CarregarGadosDeJson();

                Gado gadoAtualizado = gados.Find(g => g.Nome == nomeGado);
                var indice = gados.FindIndex(g => g.Nome.Equals(nomeGado, StringComparison.OrdinalIgnoreCase));
                var formato = "dd/MM/yyyy";

                if (indice >= 0)
                {
                    Console.WriteLine($"  \u001b[33mDados atuais do gado:" +
                                      $"\u001b[0m Nome: [{gados[indice].Nome}], " +
                                      $"Idade: [{gados[indice].Idade}], " +
                                      $"Leite: [{gados[indice].Leite}], " +
                                      $"Alimento: [{gados[indice].Alimento}], " +
                                      $"Abate: [{gados[indice].Abate}] ");

                    var Nome = _cadastroGadoHandler.LerString("Nome: ");
                    var DataNascimento = _cadastroGadoHandler.LerString("DataNascimento[dd/MM/yyy]: ");
                    var Leite = _cadastroGadoHandler.LerDouble("Leite");
                    var Alimento = _cadastroGadoHandler.LerDouble("Alimento");
                    var Idade = _gadoService.CalcularIdade(DateTime.ParseExact(DataNascimento, formato, CultureInfo.InvariantCulture));

                    gados[indice].Nome = Nome;
                    gados[indice].DataNascimento = DateTime.ParseExact(DataNascimento, formato, CultureInfo.InvariantCulture);
                    gados[indice].Leite = Leite;
                    gados[indice].Alimento = Alimento;
                    gados[indice].Idade = Idade;
                    
                    _gadoService.PreencherCampoAbate(gados);
                    _cadastroGadoHandler.EditarGado(gados);
                    Console.WriteLine($" \u001b[32m[{nomeGado}] editada com sucesso\u001b[0m");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}