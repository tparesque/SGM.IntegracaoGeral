using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Dto.Autenticacao;
using SGM.IntegracaoGeral.Api.Interface;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Controllers
{
	[EnableCors("ApiCorsPolicy")]
	[Route("api/authentication")]
	[ApiController]
	public class AuthenticationController : Controller
	{
		private readonly IAutenticacaoService _autenticacaoService;

		public AuthenticationController(IAutenticacaoService autenticacaoService)
		{
			_autenticacaoService = autenticacaoService;
		}

        [AllowAnonymous]
        [HttpPost]
        public async Task<ResultDto<UsuarioDto>> Post([FromBody] UsuarioDto usuarioDto)
        {
            return await _autenticacaoService.SalvarUsuario(usuarioDto);
        }

        [AllowAnonymous]
		[HttpPost("login")]
		public async Task<ResultDto<AuthenticatedDto>> Auth(AuthDto authDto)
		{
			return await _autenticacaoService.Login(authDto);
		}		

		[AllowAnonymous]
		[HttpPost("recuperar-senha")]
		public async Task<ResultDto<bool>> RecuperarSenha(RecuperarSenhaDto dto)
		{
			return await _autenticacaoService.RecuperarSenha(dto);
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("enviar-email-recuperacao-senha")]
		public async Task<ResultDto<bool>> EnviarEmailDeRecuperacaoDeSenha([FromBody] UsuarioDto usuarioDto)
		{
			return await _autenticacaoService.EnviarEmailRecuperarSenha(usuarioDto);
		}		
	}
}
