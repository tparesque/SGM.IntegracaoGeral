using System;

namespace SGM.IntegracaoGeral.Api.Dto.ServicosAoCidadao
{
	public class HistoricoSolicitacaoDto
	{
		public Guid HistoricoSolicitacaoId { get; set; }
		public Guid UsuarioAlteracaoId { get; set; }
		public string UsuarioAlteracaoNome { get; set; }		
		public int SituacaoId { get; set; }
		public string SituacaoNome { get; set; }		
		public string DataAlteracao { get; set; }	
	}
}
