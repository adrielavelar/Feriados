using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feriados.Dominio.Entidades;
using Feriados.Dominio.Interfaces;
using Feriados.Dominio.Interfaces.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feriados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeriadosController : ControllerBase
    {
        private readonly IFeriadoServico _servico;
        private readonly IFeriadoRepositorio _repositorio;

        public FeriadosController(IFeriadoServico servico, IFeriadoRepositorio repositorio)
        {
            _servico = servico;
            _repositorio = repositorio;
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

        [HttpPost]
        [Route("ProcessaFeriados")]
        public async Task ProcessaFeriados()
        {
            await _servico.ProcessaFeriados();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var feriados = await _repositorio.ObtemFeriados();

            if (feriados.Any())
            {
                return Ok(feriados);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Feriado feriado)
        {
            var resultado = await _repositorio.EditarFeriado(feriado);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _repositorio.ExcluirFeriado(id);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
    }
}