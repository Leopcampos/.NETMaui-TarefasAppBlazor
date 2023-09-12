namespace TarefasAppBlazor.Services.Models.Responses
{
    /// <summary>
    /// Modelo de dados para a resposta de criação de conta de usuários
    /// </summary>
    public class CriarContaResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
}