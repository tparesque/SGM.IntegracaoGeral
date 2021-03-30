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
	public class UsuarioService : Service, IUsuarioService
	{
		private readonly HttpClient _httpClient;

		public UsuarioService(HttpClient httpClient, IOptions<Urls> urls)
		{
			httpClient.BaseAddress = new Uri(urls.Value.ApiAutenticacao);
			_httpClient = httpClient;
		}

		public async Task<ResultDto<IEnumerable<UsuarioDto>>> ObterTodosUsuarios()
		{
			var response = await _httpClient.GetAsync("/api/autenticacao/usuarios/usuarios");
			return await DeserializarObjetoResponse<ResultDto<IEnumerable<UsuarioDto>>>(response);
		}

		public async Task<ResultDto<IEnumerable<UsuarioDto>>> ObterTodos()
		{
			var response = await _httpClient.GetAsync("/api/autenticacao/usuarios");
			return await DeserializarObjetoResponse<ResultDto<IEnumerable<UsuarioDto>>>(response);
		}

		public async Task<ResultDto<UsuarioDto>> GetUserById(string usuarioId)
		{
			var response = await _httpClient.GetAsync("/api/autenticacao/usuarios/" + usuarioId);
			return await DeserializarObjetoResponse<ResultDto<UsuarioDto>>(response);
		}

		public async Task<ResultDto<UsuarioDto>> Update(UsuarioDto usuarioDto)
		{
			var response = await _httpClient.PutAsync("/api/autenticacao/usuarios/" + usuarioDto.Id, ObterStringContent(usuarioDto));
			return await DeserializarObjetoResponse<ResultDto<UsuarioDto>>(response);
		}

		public async Task<ResultDto<bool>> AtualizarSenha(UsuarioDto usuarioDto)
		{
			var response = await _httpClient.PutAsync("/api/autenticacao/usuarios/" + usuarioDto.Id + "/atualizar-senha", ObterStringContent(usuarioDto));
			return await DeserializarObjetoResponse<ResultDto<bool>>(response);
		}

		public async Task<ResultDto<UsuarioDto>> Salvar(UsuarioDto usuarioDto)
		{
			var response = await _httpClient.PostAsync("/api/autenticacao/usuarios", ObterStringContent(usuarioDto));
			return await DeserializarObjetoResponse<ResultDto<UsuarioDto>>(response);
		}

		public async Task<ResultDto<bool>> Delete(string usuarioId)
		{
			var response = await _httpClient.DeleteAsync("/api/autenticacao/usuarios/" + usuarioId);
			return await DeserializarObjetoResponse<ResultDto<bool>>(response);
		}       
    }	
}
