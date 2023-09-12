namespace TarefasAppBlazor.Services.Models.Responses
{
    /// <summary>
    /// Modelo de dados para a resposta de consulta de tarefas
    /// </summary>
    public class TarefasConsultaResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? DataInicio { get; set; }
        public string? DataFim { get; set; }
        public string? Categoria { get; set; }
        public string? Descricao { get; set; }
        public Guid? UsuarioId { get; set; }
    }
}