using Exercicio_14.Infrastructure.IOC;
using Exercicio_14.Presentation.UI;
using Microsoft.Extensions.DependencyInjection;

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
