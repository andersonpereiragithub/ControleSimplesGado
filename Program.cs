using System;

namespace Exercicio_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Gados.escolherMenu();
        }
        public static void cadastroGado()
        {
            Gados[] gado = new Gados[100];
            int mesNasc, anoNasc;

            for (int i = 0; i < gado.Length; i++)
            {
                gado[i] = new Gados();

                Console.Write("Infome Código: ");
                gado[i].setCodigo(Convert.ToInt32(Console.ReadLine()));

                Console.Write("Quantos Litros de Leite: ");
                gado[i].setLeite(Convert.ToDouble(Console.ReadLine()));

                Console.Write("Quantidade alimento por kg: ");
                gado[i].setAlimento(Convert.ToDouble(Console.ReadLine()));

                Console.Write("Mês nascimento: ");
                mesNasc = Convert.ToInt32(Console.ReadLine());
               
                Console.Write("Ano nascimento: ");
                anoNasc = Convert.ToInt32(Console.ReadLine());

                gado[i].setIdade(mesNasc, anoNasc);

                gado[i].setAbate(gado[i].getLeite(), gado[i].getIdade(), gado[i].getAlimento());

                char ch; 
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Deseja cadastrar outro? [N] ou [S]: ");
                Console.ResetColor();
               
                ch = Convert.ToChar(Console.ReadLine());

                switch (ch)
                {
                    case 'S':
                        cadastroGado();
                        break;

                    case 's':
                        cadastroGado();
                        break;

                    case 'N':
                        Gados.escolherMenu();
                        break;

                    case 'n':
                        Gados.escolherMenu();
                        break;
                }
            }
        }
        public static void lerDadosGados()
        {
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("================== Gados ================");
            Console.ResetColor();
            for (int i = 0; i < 100; i++)
            {  
                Gados[] gado = new Gados[100];
                
                Console.Write("Código: {0} \nLeite: {1} \nAlimento: {2} \nIdade: {3}\n",
                                gado[i].getCodigo(),
                                gado[i].getLeite(),
                                gado[i].getAlimento(),
                                gado[i].getIdade());
                Console.WriteLine("------------------------------");
            }
        }
    }
}
