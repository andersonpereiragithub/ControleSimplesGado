using Exercicio_14.Application.Services;
using Exercicio_14.Presentation.Handlers;
using Exercicio_14.Presentation.Menu;
using EXERCICIO14.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Exercicio_14.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Registra os serviços
            services.AddSingleton<IGadoService, GadoService>();
            services.AddSingleton<Menu>();
            services.AddSingleton<CadastroGadoHandler>();

            return services.BuildServiceProvider();
        }
    }
}
