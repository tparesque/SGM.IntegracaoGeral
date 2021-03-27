using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Dto.Autenticacao;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Interface
{	public interface IAutenticacaoService
	{
		Task<ResultDto<AuthenticatedDto>> Login(AuthDto authDto);
		Task<ResultDto<UsuarioDto>> SalvarUsuario(UsuarioDto usuarioDto);
		Task<ResultDto<bool>> EnviarEmailRecuperarSenha(UsuarioDto usuarioDto);
		Task<ResultDto<bool>> RecuperarSenha(RecuperarSenhaDto dto);
	}
}
