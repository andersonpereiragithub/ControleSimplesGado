﻿using System;
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

        public void CalcularIdade(DateTime dataNascimento)
        {
           DataT
            Idade = diasDeVida / 365;
        }
    }
}

