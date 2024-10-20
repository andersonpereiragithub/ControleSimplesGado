using System;
using Exercicio_14.Application.Interfaces;
using Exercicio_14.Domain.Entities;
using Exercicio_14.Presentation.Handlers;

namespace Exercicio_14.Presentation.UI
{
    public class Menu
    {
        private readonly IGadoService _gadoService;
        private readonly CadastroGadoHandler _cadastroGadoHandler;
        private const int NUM_GADOS = 3;
        private Gado[] gado = new Gado[NUM_GADOS];

        public Menu(IGadoService gadoService)
        {
            _gadoService = gadoService;
            _cadastroGadoHandler = new CadastroGadoHandler(); // Injeção da classe responsável pelo cadastro
        }

        public void AbrirMenu()
        {
            char opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("========= MENU ========");
                Console.WriteLine("(\u001b[31ma\u001b[0m) - Cadastrar Gado");
                Console.WriteLine("(\u001b[31mb\u001b[0m) - Preencher o campo Abate");
                Console.WriteLine("      \u001b[33mRelatórios:\u001b[0m");
                Console.WriteLine("                |__(\u001b[31mc\u001b[0m) - Imprimir quantidade total de LEITE produzida");
                Console.WriteLine("                |__(\u001b[31md\u001b[0m) - Imprimir quantidade total de ALIMENTO consumido");
                Console.WriteLine("                |__(\u001b[31me\u001b[0m) - Imprimir quantidade total de LEITE após Abate");
                Console.WriteLine("                |__(\u001b[31mf\u001b[0m) - Imprimir quantidade total de ALIMENTO após Abate");
                Console.WriteLine("                |__(\u001b[31mg\u001b[0m) - Imprimir número de gados para ABATE");
                Console.WriteLine("(\u001b[31mh\u001b[0m) - Sair");
                Console.WriteLine("=======================");
                Console.Write("\u001b[31mOpção: \u001b[0m");
                opcao = Console.ReadLine().ToLower()[0];

                switch (opcao)
                {
                    case 'a':
                        InstanciarGados();
                        break;
                    case 'b':
                        _gadoService.PreencherCampoAbate(gado);
                        break;
                    case 'c':
                        Console.WriteLine($"Total de leite: {_gadoService.CalcularTotalLeite(gado)} litros");
                        break;
                    case 'd':
                        Console.WriteLine($"Total de alimento: {_gadoService.CalcularTotalAlimento(gado)} kg");
                        break;
                    case 'e':
                        Console.WriteLine($"Total de leite após abate: {_gadoService.CalcularTotalLeite(gado, true)} litros");
                        break;
                    case 'f':
                        Console.WriteLine($"Total de alimento após abate: {_gadoService.CalcularTotalAlimento(gado, true)} kg");
                        break;
                    case 'g':
                        Console.WriteLine($"Total de gados para abate: {_gadoService.ContarGadoParaAbate(gado)}");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            } while (opcao != 'h');
        }

        private void InstanciarGados()
        {
            for (int i = 0; i < gado.Length; i++)
            {
                Console.WriteLine($"Cadastro do {i + 1}º gado:");
                gado[i] = _cadastroGadoHandler.ObterNovoGado();
            }
        }
    }
}