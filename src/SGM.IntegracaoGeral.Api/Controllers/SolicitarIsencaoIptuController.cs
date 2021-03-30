using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Interface;
using SGM.IntegracaoGeral.Api.Models;
using SGM.IntegracaoGeral.Api.Dto.ServicosAoCidadao;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SGM.IntegracaoGeral.Api.Controllers
{
	[ApiController]
	[EnableCors("ApiCorsPolicy")]
	[Route("api/gateway/solicitacao/isencao-iptu")]
	[Authorize]
	public class SolicitarIsencaoIptuController : Controller
	{
		private readonly ISolicitarIsencaoIptuService _solicitarIsencaoIptuService;

		public SolicitarIsencaoIptuController(ISolicitarIsencaoIptuService solicitarIsencaoIptuService)
		{
			_solicitarIsencaoIptuService = solicitarIsencaoIptuService;
		}

		[HttpPost]
		public async Task<ResultDto<bool>> Criar([FromBody] SolicitacaoIsencaoIptuRequest solicitacaoIsencaoIptuRequest)
		{
			var result = await _solicitarIsencaoIptuService.CriarSolicitacaoIsencaoIptu(solicitacaoIsencaoIptuRequest);

			return result;
		}

		[HttpGet]
		public async Task<ResultDto<List<SolicitacaoIsencaoIptuDto>>> ObterTodos()
		{
			var result = await _solicitarIsencaoIptuService.ObterTodasSolicitacoesIptu();

			return result;
		}

		[HttpGet("{id}")]
		public async Task<ResultDto<SolicitacaoIsencaoIptuDto>> ObterPorId(Guid id)
		{
			return await _solicitarIsencaoIptuService.ObterPorId(id);
		}
	}
}
