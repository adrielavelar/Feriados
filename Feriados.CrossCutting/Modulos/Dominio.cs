using System;
using Feriados.Dominio.Interfaces;
using Feriados.Dominio.Servicos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Feriados.CrossCutting.Modulos
{
    public static class Dominio
    { 
        internal static void Registrar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFeriadoServico, FeriadoServico>();
        }
    }
}
