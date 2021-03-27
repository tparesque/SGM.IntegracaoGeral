using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Dto.Autenticacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Interface
{	public interface IUsuarioService
	{		
		Task<ResultDto<IEnumerable<UsuarioDto>>> ObterTodosUsuarios();
		Task<ResultDto<IEnumerable<UsuarioDto>>> ObterTodos();
		Task<ResultDto<UsuarioDto>> GetUserById(string id);		
		Task<ResultDto<UsuarioDto>> Salvar(UsuarioDto usuarioDto);
		Task<ResultDto<UsuarioDto>> Update(UsuarioDto usuarioDto);				
		Task<ResultDto<bool>> AtualizarSenha(UsuarioDto usuarioDto);
		Task<ResultDto<bool>> Delete(string usuarioId);		
	}
}
