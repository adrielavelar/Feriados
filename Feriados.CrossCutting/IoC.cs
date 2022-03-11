using System;
using Feriados.CrossCutting.Modulos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Feriados.CrossCutting
{
    public static class IoC
    {
       public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
        {
            Dados.Registrar(services, configuration);
            Modulos.Dominio.Registrar(services, configuration);

            return services;
        }
    }
}
