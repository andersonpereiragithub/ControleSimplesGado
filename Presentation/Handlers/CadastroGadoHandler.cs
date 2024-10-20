// Nova classe responsável por lidar com o cadastro dos gados
using System;
using Exercicio_14.Domain.Entities;

namespace Exercicio_14.Presentation.Handlers
{
    public class CadastroGadoHandler
    {
        public Gado ObterNovoGado()
        {
            var gado = new Gado();

            Console.Write("Código: ");
            gado.Codigo = int.Parse(Console.ReadLine());

            Console.Write("Leite: ");
            gado.Leite = double.Parse(Console.ReadLine());

            Console.Write("Alimento: ");
            gado.Alimento = double.Parse(Console.ReadLine());

            Console.Write("Mês de nascimento: ");
            int mesNasc = int.Parse(Console.ReadLine());

            Console.Write("Ano de nascimento: ");
            int anoNasc = int.Parse(Console.ReadLine());

            gado.CalcularIdade(mesNasc, anoNasc, DateTime.Now.Month, DateTime.Now.Year);

            return gado;
        }
    }
}
