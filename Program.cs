using System;

namespace Exercicio_14
{
    class Program
    {
        const int GADOS = 3;
        static void imprimirQntdeLeite(Gados[] vet)
        {
            int i;
            double soma = 0;

            for (i = 0; i < vet.Length; i++)
            {
                soma += vet[i].getLeite();
            }
            Console.Write("\nConsumo total de Leite na Fazenda por semana foi de: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ResetColor();
            Console.WriteLine();

            abrirMenu();
        }
static void imprimirQntdeAlimento(Gados[] vet)
        {
            int i;
            double soma = 0;

            for (i = 0; i < vet.Length; i++)
            {
                soma += vet[i].getAlimento();
            }
            Console.Write("\nConsumo total de Alimento na Fazenda por semana foi de: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ResetColor();
            Console.WriteLine();

            abrirMenu();
        }
        public static void instaciaGado()
        {
            int i;
            Gados[] gado = new Gados[GADOS];

            for (i = 0; i < gado.Length; i++)
            {
                Console.WriteLine("{0}o gado:", i + 1);
                gado[i] = obterNovoGado();
            }
            abrirMenu();
        }
        static Gados obterNovoGado()
        {
            int mesNascimento, anoNascimento;

            Gados g = new Gados();

            Console.Write("Código: ");
            g.setCodigo(Convert.ToInt32(Console.ReadLine()));

            Console.Write("Leite: ");
            g.setLeite(Convert.ToDouble(Console.ReadLine()));

            Console.Write("Alimento: ");
            g.setAlimento(Convert.ToDouble(Console.ReadLine()));

            Console.Write("Mês nascimento: ");
            mesNascimento = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ano nascimento: ");
            anoNascimento = Convert.ToInt32(Console.ReadLine());

            g.setIdade(mesNascimento, anoNascimento);

            return g;
        }
        public static void abrirMenu()
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
                    instaciaGado();
                    break;
                case 'A':
                    instaciaGado();
                    break;

                case 'b':
                    //verificaAbate();
                    break;

                case 'c':
                    //imprimirQntdeLeite(VERIFICAR COMO ENVIAR PARÂMETRO);
                    break;

                case 'd':
                    //imprimirQntdeAlimento(VERIFICAR COMO ENVIAR PARÂMETRO);
                    break;

                case 'e':
                    break;

                case 'f':
                    break;

                case 'g':
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
            abrirMenu();
        }
    }
}
