
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Dto.Autenticacao;
using SGM.IntegracaoGeral.Api.Interface;

namespace SGM.IntegracaoGeral.Api.Controllers
{
    [EnableCors("ApiCorsPolicy")]    
    [Route("api/estados")]
    [Authorize]
    [ApiController]
    public class EstadoController : Controller
    {
        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        [Authorize(Roles = "Administrador,Gestor,Usuario,Funcionário")]
        [HttpGet("")]
        [ProducesResponseType(typeof(ResultDto<IEnumerable<EstadoDto>>), 200)]
        public async Task<ResultDto<IEnumerable<EstadoDto>>> Get()
        {
            return await _estadoService.ObterTodos();
        } 
    }
}
