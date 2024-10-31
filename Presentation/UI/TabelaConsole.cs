using System;
using System.Collections.Generic;
using System.Text;

namespace EXERCICIO14.Presentation.UI
{
    internal class TabelaConsole
    {
        private List<string[]> linhas = new List<string[]>();
        private string[] cabecalho; 
        private int[] larguraColunas;

        public void DefinirCabecalho(params string[] cabecalho)
        {
            this.cabecalho = cabecalho;
            this.larguraColunas = new int[cabecalho.Length];

            for (int i = 0; i < cabecalho.Length; i++)
            {
                larguraColunas[i] = cabecalho[i].Length;
            }
        }

        public void AdicionarLinha(params string[] linha)
        {
            if (linha.Length != cabecalho.Length)
            {
                throw new ArgumentException("Número de colunas não coincide com o cabeçalho.");
            }

            for (int i = 0; i < linha.Length; i++)
            {
                if (linha[i].Length > larguraColunas[i])
                {
                    larguraColunas[i] = linha[i].Length;
                }
            }
            linhas.Add(linha);
        }

        public void DesenharTabela()
        {
            DesenharLinhaSeparadora();
            DesenharLinha(cabecalho);
            DesenharLinhaSeparadora();

            foreach (var linha in linhas)
            {
                DesenharLinha(linha);
            }
            DesenharLinhaSeparadora();
        }

        private void DesenharLinha(string[] linha)
        {
            for (int i = 0; i < linha.Length; i++)
            {
                bool alinharDireitaSeValor = cabecalho[i] == "LEITE" ||
                                             cabecalho[i] == "LEITE L" ||
                                             cabecalho[i] == "ALIMENTO" ||
                                             cabecalho[i] == "ALIMENTO KG" ||
                                             cabecalho[i] == "IDADE";
                
                if (alinharDireitaSeValor)
                {
                    Console.Write("| " + linha[i].PadLeft(larguraColunas[i]) + " ");
                }
                else
                {
                    Console.Write("| " + linha[i].PadRight(larguraColunas[i]) + " ");
                }
            }
            Console.WriteLine("|");
        }

        private void DesenharLinhaSeparadora()
        {
            for (int i = 0; i < cabecalho.Length; i++)
            {
                Console.Write("+");
                Console.Write(new string('-', larguraColunas[i] + 2));
            }
            Console.WriteLine("+");
        }
    }
}
