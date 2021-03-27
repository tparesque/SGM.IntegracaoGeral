using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Models;
using SGM.IntegracaoGeral.Api.Dto.ServicosAoCidadao;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SGM.IntegracaoGeral.Api.Interface
{
	public interface  ISolicitarIsencaoIptuService
	{
		Task<ResultDto<bool>> CriarSolicitacaoIsencaoIptu(SolicitacaoIsencaoIptuRequest request);
		Task<ResultDto<List<SolicitacaoIsencaoIptuDto>>> ObterTodasSolicitacoesIptu();
		Task<ResultDto<SolicitacaoIsencaoIptuDto>> ObterPorId(Guid solicitacaoId);


	}
}
