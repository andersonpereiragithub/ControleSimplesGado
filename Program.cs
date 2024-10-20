using Microsoft.Extensions.DependencyInjection;
using Exercicio_14.Infrastructure.IOC;
using Exercicio_14.Presentation.UI;
using System;

namespace Exercicio_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependencyInjection.ConfigureServices();

            var menu = serviceProvider.GetService<Menu>();
            menu.AbrirMenu();
        }
    }
}
