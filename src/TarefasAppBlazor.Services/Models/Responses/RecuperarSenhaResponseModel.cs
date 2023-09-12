namespace TarefasAppBlazor.Services.Models.Responses
{
    /// <summary>
    /// Modelo de dados para a resposta de recuperação de senha de usuários
    /// </summary>
    public class RecuperarSenhaResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
}