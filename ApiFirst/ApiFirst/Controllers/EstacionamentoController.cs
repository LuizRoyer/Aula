using ApiFirst.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstacionamentoController : ControllerBase
    {
        private List<Estacionamento> listaCarros = new List<Estacionamento>() {
            new Estacionamento(){ Placa = "hga3890", Modelo= "Moto" },
       new Estacionamento(){ Placa = "frs1243", Modelo= "Moto" },
       new Estacionamento(){ Placa = "sdgf1234", Modelo= "Moto" },
    };
        [HttpGet("[action]")]
        public List<Estacionamento> RetornaCarros()
        {
            return listaCarros;
        }
        [HttpPost("[action]")]
        public int InserirCarro([FromBody] Estacionamento estacionamento)
        {
            listaCarros.Add(estacionamento);
            return 1;
        }
        [HttpPut("[action]/{placa}")]
        public int Update(string placa ,[FromBody]Estacionamento estacionamento)
        {

            return 1;
        }
    }
}