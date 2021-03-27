using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Models;
using SGM.IntegracaoGeral.Api.Dto.ServicosAoCidadao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Interface
{	public interface ISolicitarConcertoIluminacaoService
	{
		Task<ResultDto<bool>> CriarSolicitacaoReparo(SolicitacaoReparoRequest request);
		Task<ResultDto<List<SolicitarConcertoIluminacaoDto>>> ObterSolicitacaoReparo();
        Task<ResultDto<SolicitarConcertoIluminacaoDto>> ObterPorId(Guid solicitacaoId);
        Task<ResultDto<bool>> IniciarAtendimento(Guid solicitacaoId);
        Task<ResultDto<bool>> FinalizarAtendimento(Guid solicitacaoId);
        Task<ResultDto<bool>> Delete(Guid solicitacaoId);
    }
}
