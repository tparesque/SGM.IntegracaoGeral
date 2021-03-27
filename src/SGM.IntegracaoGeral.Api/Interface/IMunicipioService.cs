using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Dto.Autenticacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Interface
{	public interface IMunicipioService
	{
		Task<ResultDto<IEnumerable<MunicipioDto>>> ObterTodosPorEstado(int estadoId);
	}
}
