using System;

namespace Exercicio_14
{
    class Gados
    {
        private int codigo;
        private int idade;
        private double leite;
        private double alimento;
        private string abate;

            public int getCodigo()
            {
                return codigo;
            }
            public void setCodigo(int novoCodigo)
            {
                codigo = novoCodigo;
            }
            public double getLeite()
            {
                return leite;
            }
            public void setLeite(double novoLeite)
            {
                leite = novoLeite;
            }
            public double getAlimento()
            {
                return alimento;
            }
            public void setAlimento(double novoAlimento)
            {
                alimento = novoAlimento;
            }

            public string getAbate()
            {
                return abate;
            }
            public void setAbate(double novoLeite, int novaIdade, double novoAlimento)
            {
                if (novaIdade > 5 || novoLeite < 40 || novoLeite > 50 && novoLeite < 70 && novoAlimento > 50)
                {
                    abate = "SIM";
                }
                else
                {
                    abate = "NÃO";
                }
            }

            public int getIdade()
            {
                return idade;
            }
            public void setIdade(int mesNascimento, int AnoNascimento)
            {
                idade = calculaIdade(mesNascimento, AnoNascimento);
            }
            public int calculaIdade(int mesNascimento, int anoNascimento)
            {
                int mesAtual = 12;
                int anoAtual = 2019;
                int idadeMes = (mesAtual - mesNascimento) * 30;
                return (idadeMes + ((anoAtual - anoNascimento) * 365)) / 365;
            }
            public static void escolherMenu()
            {
                char ch;
                // Menu de OPÇÕES
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========= MENU ========");
                Console.ResetColor();
                Console.WriteLine("(a) - Cadastrar Gado");
                Console.WriteLine("(b) - Preencher o campo Abate");
                Console.WriteLine("(c) - Imprimrir a quantidade de LEITE produzida por semana na fazenda");
                Console.WriteLine("(d) - Imprimrir a quantidade total de ALIMENTO consumido na fazenda o Abate");
                Console.WriteLine("(e) - Imprimrir a quantidade total de leite produzido por semana, após o Abate");
                Console.WriteLine("(f) - Imprimrir a quantidade total de alimento que vai ser consumido por semana na fazenda,");
                Console.WriteLine("      após o Abate");
                Console.WriteLine("(g) - Imprimrir número de cabeças de gado que irão para abate");
                Console.WriteLine("(h) - Sair do Menu");
                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Digite a opção desejada: ");
                Console.ResetColor();
                ch = Convert.ToChar(Console.ReadLine());

                switch (ch)
                {
                    case 'a':
                        Program.cadastroGado();
                        break;

                    case 'b':
                        Gados novos1 = new Gados();
                        novos1.verificaAbate();
                        break;

                    case 'c':

                        break;

                    case 'd':
                        break;

                    case 'e':
                        break;

                    case 'f':
                        break;

                    case 'g':
                        Program.lerDadosGados();
                        break;

                    case 'h':
                        Environment.Exit(0);
                        break;
                }

            }


            public void verificaAbate()
            {
                Gados[] gado = new Gados[2];
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("============== Gados para ABATE =============");
                Console.ResetColor();
                for (int i = 0; i < gado.Length - 1; i++)
                {
                    gado = new Gados[2];
                    Console.WriteLine("Código: {0} vai para {1}", gado[i].getCodigo(), gado[i].getAbate());
                }
            }

        }
    }
