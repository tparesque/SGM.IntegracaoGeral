using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Interface;
using SGM.IntegracaoGeral.Api.Models;
using SGM.IntegracaoGeral.Api.Dto.ServicosAoCidadao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Controllers
{
	[EnableCors("ApiCorsPolicy")]
	[Route("api/solicitacaoReparo")]
	[Authorize]
	[ApiController]
	public class SolicitarConcertoIluminacaoController : Controller
	{
		private readonly ISolicitarConcertoIluminacaoService _solicitarConcertoIluminacaoService;

		public SolicitarConcertoIluminacaoController(ISolicitarConcertoIluminacaoService solicitarConcertoIluminacaoService)
		{
			_solicitarConcertoIluminacaoService = solicitarConcertoIluminacaoService;
		}

		[HttpPost]				
		public async Task<ResultDto<bool>> CriarSolicitacaoReparo([FromBody] SolicitacaoReparoRequest solicitacaoReparoRequest)
		{
			return await _solicitarConcertoIluminacaoService.CriarSolicitacaoReparo(solicitacaoReparoRequest);
		}

		[HttpGet]
		public async Task<ResultDto<List<SolicitarConcertoIluminacaoDto>>> ObterSolicitacaoReparo()
		{
			return await _solicitarConcertoIluminacaoService.ObterSolicitacaoReparo();
		}
				
		[HttpGet("{id}")]		
		public async Task<ResultDto<SolicitarConcertoIluminacaoDto>> ObterPorId(Guid id)
		{
			return await _solicitarConcertoIluminacaoService.ObterPorId(id);
		}

		[Authorize(Roles = "Administrador,Funcionário")]
		[HttpPut("{id}/iniciarAtendimento")]		
		public async Task<ResultDto<bool>> IniciarAtendimento(Guid id)
		{
			return await _solicitarConcertoIluminacaoService.IniciarAtendimento(id);
		}

		[Authorize(Roles = "Administrador,Funcionário")]
		[HttpPut("{id}/finalizarAtendimento")]		
		public async Task<ResultDto<bool>> FinalizarAtendimento(Guid id)
		{
			return await _solicitarConcertoIluminacaoService.FinalizarAtendimento(id);
		}

		[Authorize(Roles = "Administrador,Gerente")]
		[HttpDelete("{id}")]		
		public async Task<ResultDto<bool>> Delete(Guid id)
		{
			return await _solicitarConcertoIluminacaoService.Delete(id);
		}
	}
}
