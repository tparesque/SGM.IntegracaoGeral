using Microsoft.Extensions.Options;
using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Configuration;
using SGM.IntegracaoGeral.Api.Interface;
using SGM.IntegracaoGeral.Api.Dto.SAFiM;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Services
{
	public class SalarioServidorService : Service, ISalarioServidorService
    {
		private readonly HttpClient _httpClient;

		public SalarioServidorService(HttpClient httpClient, IOptions<Urls> urls)
		{
			httpClient.BaseAddress = new Uri(urls.Value.ApiSAFiM);
			_httpClient = httpClient;
		}		

        public async Task<ResultDto<List<SalarioServidorDto>>> ObterTodos(string matricula, string nome, string mesReferencia, string anoReferencia)
        {
            var url = @$"/api/safim/salarioServidor?matricula={matricula}&nome={nome}&mesReferencia={mesReferencia}&anoReferencia={anoReferencia}";
            var response = await _httpClient.GetAsync(url);
            return await DeserializarObjetoResponse<ResultDto<List<SalarioServidorDto>>>(response);
        }
    }	
}
