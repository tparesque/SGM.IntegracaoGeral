using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Interface;
using SGM.IntegracaoGeral.Api.Dto.SAFiM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Controllers
{
	[EnableCors("ApiCorsPolicy")]
	[Route("api/salarioServidor")]
	[Authorize]
	[ApiController]
	public class SalarioServidorController : Controller
	{
		private readonly ISalarioServidorService _salarioServidorService;

		public SalarioServidorController(ISalarioServidorService salarioServidorService)
		{
			_salarioServidorService = salarioServidorService;
		}		

		[HttpGet]
		public async Task<ResultDto<List<SalarioServidorDto>>> ObterSalarioServidor(string matricula, string nome, string mesReferencia, string anoReferencia)
		{
			return await _salarioServidorService.ObterTodos(matricula, nome, mesReferencia, anoReferencia);
		}	
	}
}
