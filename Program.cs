using Exercicio_14.Presentation.Menu;
using Exercicio_14.Infrastructure.DI;
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
