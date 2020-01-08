using System;

namespace Exercicio_14
{
    class Program
    {
        const int NUM_GADOS = 3;
        static void preencheCampoAbate(Gados[] gado)
        {
            for (int i = 0; i < gado.Length; i++)
            {
                gado[i].setAbate(gado[i].getLeite(), gado[i].getIdade(), gado[i].getAlimento());
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nClassificação de ABATE concluída com sucesso!");
            Console.ResetColor();
            Console.WriteLine("\nAperte uma tecla para continuar...");
            Console.ReadKey();

            abrirMenu(gado);
        }
        static void imprimeNumAbate(Gados[] gado)
        {
            int i;
            double soma = 0;

            for (i = 0; i < gado.Length; i++)
            {
                gado[i].setAbate(gado[i].getLeite(), gado[i].getIdade(), gado[i].getAlimento());
                if (gado[i].getAbate() == "SIM")
                {
                    soma++;
                }
            }
            Console.Write("\nTotal de gado para ABATE é: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}", soma);
            Console.ResetColor();
            Console.WriteLine("\nAperte uma tecla para continuar...");
            Console.ReadKey();

            abrirMenu(gado);
        }
        static void imprimirQntdeLeite(Gados[] gado)
        {
            int i;
            double soma = 0;

            for (i = 0; i < gado.Length; i++)
            {
                soma += gado[i].getLeite();
            }
            Console.Write("\nConsumo total de Leite na Fazenda por semana foi de: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}", soma);
            Console.ResetColor();
            Console.WriteLine("\nAperte uma tecla para continuar...");
            Console.ReadKey();

            abrirMenu(gado);
        }
        static void imprimirQntdeAlimento(Gados[] gado)
        {
            int i;
            double soma = 0;

            for (i = 0; i < gado.Length; i++)
            {
                soma += gado[i].getAlimento();
            }
            Console.Write("\nConsumo total de Alimento na Fazenda por semana foi de: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}", soma);
            Console.ResetColor();
            Console.WriteLine("\nAperte uma tecla para continuar...");
            Console.ReadKey();

            abrirMenu(gado);
        }
        public static void instanciaGado(Gados[] gado)
        {
            int i;

            for (i = 0; i < gado.Length; i++)
            {
                Console.WriteLine("\n{0}o gado:", i + 1);
                gado[i] = obterNovoGado();
            }
            abrirMenu(gado);
        }
        static Gados obterNovoGado()
        {
            int mesNascimento, anoNascimento;
            Gados gado = new Gados();

            Console.Write("Código: ");
            gado.setCodigo(Convert.ToInt32(Console.ReadLine()));

            Console.Write("Leite: ");
            gado.setLeite(Convert.ToDouble(Console.ReadLine()));

            Console.Write("Alimento: ");
            gado.setAlimento(Convert.ToDouble(Console.ReadLine()));

            Console.Write("Mês nascimento: ");
            mesNascimento = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ano nascimento: ");
            anoNascimento = Convert.ToInt32(Console.ReadLine());

            gado.setIdade(mesNascimento, anoNascimento);

            return gado;
        }
        public static void abrirMenu(Gados[] gado)
        {
            char ch;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("========= MENU ========");
            Console.ResetColor();
            Console.WriteLine("(a) - Cadastrar Gado");
            Console.WriteLine("(b) - Preencher o campo Abate");
            Console.WriteLine("(c) - Imprimrir a quantidade total de LEITE produzida por semana na fazenda");
            Console.WriteLine("(d) - Imprimrir a quantidade total de ALIMENTO consumido na fazenda o Abate");
            //Console.WriteLine("(e) - Imprimrir a quantidade total de leite produzido por semana, após o Abate");
            //Console.WriteLine("(f) - Imprimrir a quantidade total de alimento que vai ser consumido por semana na fazenda,");
            //Console.WriteLine("      após o Abate");
            Console.WriteLine("(g) - Imprimrir número de cabeças de gado que irão para abate");
            Console.WriteLine("(h) - Sair do Menu");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=======================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Digite a opção desejada: ");
            Console.ResetColor();
            ch = Convert.ToChar(Console.ReadLine());

            switch (ch)
            {
                case 'a':
                    instanciaGado(gado);
                    break;
                case 'A':
                    instanciaGado(gado);
                    break;

                case 'b':
                    preencheCampoAbate(gado);
                    break;
                case 'B':
                    preencheCampoAbate(gado);
                    break;

                case 'c':
                    imprimirQntdeLeite(gado);
                    break;
                case 'C':
                    imprimirQntdeLeite(gado);
                    break;

                case 'd':
                    imprimirQntdeAlimento(gado);
                    break;
                case 'D':
                    imprimirQntdeAlimento(gado);
                    break;

                case 'e':
                    break;

                case 'f':
                    break;

                case 'g':
                    imprimeNumAbate(gado);
                    break;
                case 'G':
                    imprimeNumAbate(gado);
                    break;

                case 'h':
                    Environment.Exit(0);
                    break;
                case 'H':
                    Environment.Exit(0);
                    break;
            }
        }
        static void Main(string[] args)
        {
            Gados[] gado = new Gados[NUM_GADOS];

            abrirMenu(gado);
        }
    }
}
