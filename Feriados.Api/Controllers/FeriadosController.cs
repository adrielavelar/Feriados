using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feriados.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feriados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeriadosController : ControllerBase
    {
        private readonly IFeriadoServico _servico;

        public FeriadosController(IFeriadoServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        [Route("ObtemFeriadosApi")]
        public async Task<IActionResult> ObtemFeriadosApi()
        {
            var feriados = await _servico.ObtemFeriadosApi();

            if (feriados.Any())
            {
                return Ok(feriados);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtemFeriados()
        {
            var feriados = await _servico.ObtemFeriados();

            if (feriados.Any())
            {
                return Ok(feriados);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("ProcessaFeriados")]
        public async Task ProcessaFeriados()
        {
            await _servico.ProcessaFeriados();
        }
    }
}