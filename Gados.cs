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
            public void setAbate(double Leite, int Idade, double Alimento)
            {
                if (Idade > 5 || Leite < 40 || Leite > 50 && Leite < 70 && Alimento > 50)
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
            public void setIdade(int mesNasc, int anoNasc)
            {
                int mAtual = 1;
                int aAtual = 2020;
                int converteEmDias = (((mAtual * 30) + (aAtual * 365)) - ((mesNasc * 30) + (anoNasc * 365)));
                
                idade = converteEmDias / 365;
            }

        }
    }
