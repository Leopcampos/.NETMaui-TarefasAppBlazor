﻿namespace TarefasAppBlazor.Services.Models.Responses;

/// <summary>
/// Modelo de dados para a resposta de autenticação de usuários
/// </summary>
public class AutenticarResponseModel
{
    public string? IdUsuario { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? AccessToken { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? Expiration { get; set; }
}