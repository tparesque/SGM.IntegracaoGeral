using Microsoft.Extensions.Options;
using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Configuration;
using SGM.IntegracaoGeral.Api.Interface;
using SGM.IntegracaoGeral.Api.Dto.Autenticacao;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Services
{	

	public class AutenticacaoService : Service, IAutenticacaoService
	{
		private readonly HttpClient _httpClient;

		public AutenticacaoService(HttpClient httpClient, IOptions<Urls> urls)
		{
			httpClient.BaseAddress = new Uri(urls.Value.ApiAutenticacao);
			_httpClient = httpClient;
		}

		public async Task<ResultDto<AuthenticatedDto>> Login(AuthDto dto)
		{
			var response = await _httpClient.PostAsync("/api/autenticacao/login", ObterStringContent(dto));
			return await DeserializarObjetoResponse<ResultDto<AuthenticatedDto>>(response);
		}

		public async Task<ResultDto<UsuarioDto>> SalvarUsuario(UsuarioDto usuarioDto)
		{
			var response = await _httpClient.PostAsync("/api/autenticacao", ObterStringContent(usuarioDto));
			return await DeserializarObjetoResponse<ResultDto<UsuarioDto>>(response);
		}

		public async Task<ResultDto<bool>> EnviarEmailRecuperarSenha(UsuarioDto usuarioDto)
		{
			var response = await _httpClient.PostAsync("/api/autenticacao/enviar-email-recuperacao-senha", ObterStringContent(usuarioDto));
			return await DeserializarObjetoResponse<ResultDto<bool>>(response);
		}

		public async Task<ResultDto<bool>> RecuperarSenha(RecuperarSenhaDto dto)
		{
			var response = await _httpClient.PostAsync("/api/autenticacao/recuperar-senha", ObterStringContent(dto));
			return await DeserializarObjetoResponse<ResultDto<bool>>(response);
		}
	}	
}
