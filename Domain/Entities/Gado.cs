using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio_14.Domain.Entities
{
    public class Gado
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Leite { get; set; }
        public double Alimento { get; set; }
        public string Abate{ get; set; }

        public void DefinirAbate()
        {
            if (Idade > 5 || Leite < 40 || (Leite > 50 && Leite < 70 && Alimento > 50))
            {
                Abate = "SIM";
            }
            else
            {
                Abate = "NÃO";
            }
        }

        public void CalcularIdade(int mesNasc, int anoNasc, int mesAtual, int anoAtual)
        {
            int diasDeVida = (((mesAtual * 30) + (anoAtual * 365)) - ((mesNasc * 30) + (anoNasc * 365)));
            Idade = diasDeVida / 365;
        }
    }
}

