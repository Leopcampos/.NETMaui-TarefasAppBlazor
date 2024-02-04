using System.ComponentModel.DataAnnotations;

namespace TarefasAppBlazor.Services.Models.Requests;

/// <summary>
/// Modelo de dados para a requisição de autenticação de usuários
/// </summary>
public class AutenticarRequestModel
{
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Entre com o seu email:", Prompt ="Ex: joaodasilva@gmail.com")]
    [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
    [Required(ErrorMessage = "Por favor, informe o seu email de acesso.")]
    public string? Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Entre com a sua senha:")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Por favor, informe uma senha forte (letras maiúsculas, letras minúsculas, números, símbolos e pelo menos 8 caracteres).")]
    [Required(ErrorMessage = "Por favor, informe a sua senha de acesso.")]
    public string? Senha { get; set; }
}