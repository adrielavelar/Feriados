using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Feriados.Dominio.Entidades;
using Feriados.Dominio.Interfaces;
using Feriados.Dominio.Interfaces.Repositorios;
using Feriados.Dominio.Respostas;
using Microsoft.Extensions.Configuration;
using static Newtonsoft.Json.JsonConvert;

namespace Feriados.Dominio.Servicos
{
    public class FeriadoServico : IFeriadoServico
    {
        private readonly IConfiguration _configuration;
        private readonly IFeriadoRepositorio _feriadoRepositorio;
        static readonly HttpClient client = new HttpClient();

        private string _urlBase;

        public FeriadoServico(IConfiguration configuration, IFeriadoRepositorio feriadoRepositorio)
        {
            _configuration = configuration;
            _feriadoRepositorio = feriadoRepositorio;

            _urlBase = _configuration.GetSection("URL_BASE").Value;
        }

        public async Task<IEnumerable<FeriadoResposta>> ObtemFeriadosApi()
        {
            var uri = _urlBase + "nacionais.json";

            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();

            return DeserializeObject<IEnumerable<FeriadoResposta>>(content);
        }

        public async Task ProcessaFeriados()
        {
            var feriados = await ObtemFeriadosApi();

            foreach (var feriado in feriados)
            {

                var datas = (VariableDates)feriado.VariableDates;

                var id = await  _feriadoRepositorio.AdicionarDatas(datas);

                var feriadoEntity = (Feriado)feriado;
                feriadoEntity.VariableId = id;

                await _feriadoRepositorio.AdicionarFeriado(feriadoEntity);
            }
        }

        public Task<IEnumerable<Feriado>> ObtemFeriados()
        {
            return _feriadoRepositorio.ObtemFeriados();
        }
    }
}
