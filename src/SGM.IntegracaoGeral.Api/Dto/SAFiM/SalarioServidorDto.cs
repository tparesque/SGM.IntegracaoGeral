namespace SGM.IntegracaoGeral.Api.Dto.SAFiM
{
	public class SalarioServidorDto
	{		
		public string SalarioServidorId { get; set; }
		public string Matricula { get; set; }
		public string Nome { get; set; }
		public string Lotacao { get; set; }
		public string MesReferencia { get; set; }
		public string AnoReferencia { get; set; }
		public string RemuneracaoBruta { get; set; }
		public string Descontos { get; set; }
		public string ValorLiquido { get; set; }
	}
}
