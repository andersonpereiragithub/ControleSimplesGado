﻿using Exercicio_14.Application.Interfaces;
using Exercicio_14.Domain.Entities;
using Exercicio_14.Presentation.Handlers;
using EXERCICIO14.Presentation.UI;
using System.Collections.Generic;
using System;

namespace Exercicio_14.Presentation.UI
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
            Console.WriteLine("(\u001b[31mc\u001b[0m) - Editar Gado");
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

    }
}