using System;
using Feriados.Dominio.Interfaces.Repositorios;
using Feriados.Infra.Repositorios.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Feriados.CrossCutting.Modulos
{
    public static class Dados
    {
        private const string _connectionStringName = "MSSQL_CONNECTION";

        internal static void Registrar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFeriadoRepositorio, FeriadoRepositorio>(sp =>
                new FeriadoRepositorio(ObtemConnectionString(configuration))
            ); 
        }

        private static string ObtemConnectionString(IConfiguration configuration)
        {
            return configuration.GetSection(_connectionStringName).Value;
        }
    }
}
