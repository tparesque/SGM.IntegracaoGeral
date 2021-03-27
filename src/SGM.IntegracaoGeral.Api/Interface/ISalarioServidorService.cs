using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Dto.SAFiM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Interface
{	public interface ISalarioServidorService
    {		
		Task<ResultDto<List<SalarioServidorDto>>> ObterTodos(string matricula, string nome, string mesReferencia, string anoReferencia);      
    }
}
