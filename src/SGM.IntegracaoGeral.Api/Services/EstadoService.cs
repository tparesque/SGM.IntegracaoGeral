using Microsoft.Extensions.Options;
using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Configuration;
using SGM.IntegracaoGeral.Api.Interface;
using SGM.IntegracaoGeral.Api.Dto.Autenticacao;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Services
{	
	public class EstadoService : Service, IEstadoService
	{
		private readonly HttpClient _httpClient;

		public EstadoService(HttpClient httpClient, IOptions<Urls> urls)
		{
			httpClient.BaseAddress = new Uri(urls.Value.ApiAutenticacao);
			_httpClient = httpClient;
		}

		public async Task<ResultDto<IEnumerable<EstadoDto>>> ObterTodos()
		{
			var response = await _httpClient.GetAsync("/api/autenticacao/estados");
			return await DeserializarObjetoResponse<ResultDto<IEnumerable<EstadoDto>>>(response);			
		}
	}	
}
