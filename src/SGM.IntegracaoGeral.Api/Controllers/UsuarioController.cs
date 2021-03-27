using SGM.IntegracaoGeral.Api.Dto.Autenticacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGM.IntegracaoGeral.Api.Dto;
using SGM.IntegracaoGeral.Api.Interface;

namespace SGM.IntegracaoGeral.Api.Controllers
{
    [EnableCors("ApiCorsPolicy")]    
    [Route("api/usuarios")]
    [Authorize]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize(Roles = "Administrador,Gestor,Usuario,Funcionário")]
        [HttpGet("usuarios")]
        [ProducesResponseType(typeof(ResultDto<UsuarioDto>), 200)]
        public async Task<ResultDto<IEnumerable<UsuarioDto>>> GetAllUsuarios()
        {
            return await _usuarioService.ObterTodosUsuarios();
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("")]
        [ProducesResponseType(typeof(ResultDto<UsuarioDto>), 200)]
        public async Task<ResultDto<IEnumerable<UsuarioDto>>> GetAll()
        {
            return await _usuarioService.ObterTodos();
        }

        [Authorize(Roles = "Administrador,Gestor,Usuario,Funcionário")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResultDto<UsuarioDto>), 200)]
        public async Task<ResultDto<UsuarioDto>> Get(string id)
        {
            return await _usuarioService.GetUserById(id);
        }

        [Authorize(Roles = "Administrador,Gestor,Usuario,Funcionário")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResultDto<UsuarioDto>), 200)]
        public async Task<ResultDto<UsuarioDto>> Put(int id, [FromBody] UsuarioDto usuarioDto)
        {
            return await _usuarioService.Update(usuarioDto);
        }

        [Authorize(Roles = "Administrador,Gestor,Usuario,Funcionário")]
        [HttpPut]
        [Route("{id}/atualizar-senha")]
        [ProducesResponseType(typeof(ResultDto<bool>), 200)]
        public async Task<ResultDto<bool>> AtualizarSenha([FromBody] UsuarioDto usuarioDto)
        {
            return await _usuarioService.AtualizarSenha(usuarioDto);           
        }


        [Authorize(Roles = "Administrador")]
        [HttpPost("")]
        [ProducesResponseType(typeof(ResultDto<UsuarioDto>), 200)]
        public async Task<ResultDto<UsuarioDto>> Post([FromBody] UsuarioDto usuarioDto)
        {
            return await _usuarioService.Salvar(usuarioDto);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResultDto<bool>), 200)]
        public async Task<ResultDto<bool>> Delete(string id)
        {
            return await _usuarioService.Delete(id);
        }
    }
}
