using System.ComponentModel.DataAnnotations;

namespace TarefasAppBlazor.Services.Models.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição de recuperação de senha de usuários
    /// </summary>
    public class RecuperarSenhaRequestModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Entre com o seu email:", Prompt = "Ex: joaodasilva@gmail.com")]
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
        [Required(ErrorMessage = "Por favor, informe o seu email de acesso.")]
        public string? Email { get; set; }
    }
}