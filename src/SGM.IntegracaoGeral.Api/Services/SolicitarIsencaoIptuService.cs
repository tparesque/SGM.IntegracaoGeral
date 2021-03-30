using Microsoft.Extensions.Options;
using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Configuration;
using SGM.IntegracaoGeral.Api.Interface;
using SGM.IntegracaoGeral.Api.Models;
using SGM.IntegracaoGeral.Api.Dto.ServicosAoCidadao;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Services
{
	public class SolicitarIsencaoIptuService : Service, ISolicitarIsencaoIptuService
	{
		private readonly HttpClient _httpClient;

		public SolicitarIsencaoIptuService(HttpClient httpClient, IOptions<Urls> urls)
		{
			httpClient.BaseAddress = new Uri(urls.Value.ApiServicosAoCidadao);

			_httpClient = httpClient;
		}

		public async Task<ResultDto<bool>> CriarSolicitacaoIsencaoIptu(SolicitacaoIsencaoIptuRequest request)
		{
			StringContent conteudo = ObterStringContent(request);

			var response = await _httpClient.PostAsync("/api/servicos-ao-cidadao/solicitacoes", conteudo);

			var objetoDeserializado = await DeserializarObjetoResponse<ResultDto<bool>>(response);
			return objetoDeserializado;
		}

		public async Task<ResultDto<List<SolicitacaoIsencaoIptuDto>>> ObterTodasSolicitacoesIptu()
		{
			var response = await _httpClient.GetAsync("/api/servicos-ao-cidadao/solicitacoes");

			var objetoDeserializado = await DeserializarObjetoResponse<ResultDto<List<SolicitacaoIsencaoIptuDto>>>(response);
			return objetoDeserializado;
		}

		public async Task<ResultDto<SolicitacaoIsencaoIptuDto>> ObterPorId(Guid solicitacaoId)
		{
			var response = await _httpClient.GetAsync("/api/servicos-ao-cidadao/solicitacoes/" + solicitacaoId.ToString());
			return await DeserializarObjetoResponse<ResultDto<SolicitacaoIsencaoIptuDto>>(response);
		}
	}
}
