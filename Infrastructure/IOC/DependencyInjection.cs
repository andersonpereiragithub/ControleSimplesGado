using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Exercicio_14.Application.Interfaces;
using Exercicio_14.Application.Services;
using Exercicio_14.Presentation.UI;
using Exercicio_14.Presentation.Handlers;

namespace Exercicio_14.Infrastructure.IOC
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
