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
	public class SolicitarConcertoIluminacaoService : Service, ISolicitarConcertoIluminacaoService
	{
		private readonly HttpClient _httpClient;

		public SolicitarConcertoIluminacaoService(HttpClient httpClient, IOptions<Urls> urls)
		{
			httpClient.BaseAddress = new Uri(urls.Value.ApiServicosAoCidadao);
			_httpClient = httpClient;
		}

		public async Task<ResultDto<bool>> CriarSolicitacaoReparo(SolicitacaoReparoRequest request)
		{
			var response = await _httpClient.PostAsync("/api/solicitacaoReparo", ObterStringContent(request));
			return await DeserializarObjetoResponse<ResultDto<bool>>(response);
		}

        public async Task<ResultDto<List<SolicitarConcertoIluminacaoDto>>> ObterSolicitacaoReparo()
        {
            var response = await _httpClient.GetAsync("/api/solicitacaoReparo");
            return await DeserializarObjetoResponse<ResultDto<List<SolicitarConcertoIluminacaoDto>>>(response);
        }

        public async Task<ResultDto<SolicitarConcertoIluminacaoDto>> ObterPorId(Guid solicitacaoId)
        {
            var response = await _httpClient.GetAsync("/api/solicitacaoReparo/" + solicitacaoId.ToString());
            return await DeserializarObjetoResponse<ResultDto<SolicitarConcertoIluminacaoDto>>(response);
        }       

        public async Task<ResultDto<bool>> IniciarAtendimento(Guid solicitacaoId)
        {
            var response = await _httpClient.PutAsync("/api/solicitacaoReparo/" + solicitacaoId.ToString() + "/iniciarAtendimento", null);
            return await DeserializarObjetoResponse<ResultDto<bool>>(response);
        }

        public async Task<ResultDto<bool>> FinalizarAtendimento(Guid solicitacaoId)
        {
            var response = await _httpClient.PutAsync("/api/solicitacaoReparo/" + solicitacaoId.ToString() + "/finalizarAtendimento", null);
            return await DeserializarObjetoResponse<ResultDto<bool>>(response);
        }

        public async Task<ResultDto<bool>> Delete(Guid solicitacaoId)
        {
            var response = await _httpClient.DeleteAsync("/api/solicitacaoReparo/" + solicitacaoId.ToString());
            return await DeserializarObjetoResponse<ResultDto<bool>>(response);
        }
    }	
}
