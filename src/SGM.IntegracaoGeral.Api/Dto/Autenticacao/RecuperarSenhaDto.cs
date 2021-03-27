namespace SGM.IntegracaoGeral.Api.Dto.Autenticacao
{
    public class RecuperarSenhaDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string NovaSenha { get; set; }
    }
}
