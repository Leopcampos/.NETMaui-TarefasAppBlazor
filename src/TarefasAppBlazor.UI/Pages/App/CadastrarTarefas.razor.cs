using Microsoft.AspNetCore.Components;
using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Models.Requests;
using TarefasAppBlazor.Services.Models.Responses;
using TarefasAppBlazor.UI.Helpers;

namespace TarefasAppBlazor.UI.Pages.App;

public partial class CadastrarTarefas
{
    [Inject]
    AuthenticationHelper AuthenticationHelper { get; set; }

    //Definindo a classe de modelo de dados do componente
    private TarefasCadastroRequestModel model = new TarefasCadastroRequestModel();

    //lista de op��es para o campo de sele��o de categoria
    private List<string> Categorias = new List<string>();

    //mensagens
    private string? mensagemProcessamento;
    private string? mensagemSucesso;
    private string? mensagemErro;

    //fun��o para capturar o  SUBMIT do formul�rio
    protected async Task OnSubmit()
    {
        mensagemProcessamento = "Processando, por favor aguarde...";

        try
        {
            //capturando os dados do usu�rio autenticado
            var user = await AuthenticationHelper.GetUser();

            var servicesHelper = new ServicesHelper(user.AccessToken);
            await servicesHelper.Post<TarefasCadastroRequestModel, TarefasConsultaResponseModel>("tarefas", model);

            this.mensagemSucesso = "Tarefa cadastrada com sucesso";
            model = new TarefasCadastroRequestModel();
        }
        catch (Exception e)
        {
            mensagemErro = e.Message;
        }
        finally
        {
            mensagemProcessamento = string.Empty;
        }
    }

    //fun��o executada ao abrir o componente
    protected override Task OnInitializedAsync()
    {
        Categorias.Add("Trabalho");
        Categorias.Add("Estudo");
        Categorias.Add("Fam�lia");
        Categorias.Add("Lazer");
        Categorias.Add("Outros");

        return Task.CompletedTask;
    }
}